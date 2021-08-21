using EFDB.DataAccess;
using EFDB.Models;
using Grpc.Core;
using grpc4InRowService.Protos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grpc4InRowService.Services
{
    public class UserService: User.UserBase
    {
        private Dictionary<Int32,String> userStreams = new Dictionary<int, String>();
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<LoginReply> Login(LoginRequest request, ServerCallContext context)
        {
            using (var db = new UsersContext())
            {
                UserModel userEntity = db.users.Single(user=>user.Username == request.Username);
                if (userEntity != null && userEntity.PW == request.Pw)
                {
                    Program.onlineUsers.Add(userEntity.Id, userEntity.Username);
                    return Task.FromResult(new LoginReply { IsSuccessfull = true });
                }
            }
            return Task.FromResult(new LoginReply { IsSuccessfull = false });
        }

        public override Task<RegisterReply> Register(RegisterRequest request, ServerCallContext context)
        {
            RegisterReply rr = new RegisterReply { IsSuccessfull = true };
            try
            {
                using (var db = new UsersContext())
                {
                    var user = new UserModel { Username = request.Username, PW = request.Pw };
                    db.users.Add(user);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                rr.IsSuccessfull = false;
            }
            return Task.FromResult(rr);
        }

        public override async Task getOnlineUsers(Req request, IServerStreamWriter<UserData> responseStream, ServerCallContext context)
        {
            foreach (var u in Program.onlineUsers)
            {
                await responseStream.WriteAsync(new UserData
                {
                    Username = u.Value
                });
            }
        }
    }
}
