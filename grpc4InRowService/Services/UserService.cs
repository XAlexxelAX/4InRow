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
        //private Dictionary<String, String> userDB = new Dictionary<string, string>();
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
            //userDB.Add("Shahar Blank", "1234");
        }

        public override Task<LoginReply> Login(LoginRequest request, ServerCallContext context)
        {
            if (Program.userDB.ContainsKey(request.Username) && Program.userDB[request.Username].Equals(request.Pw))
                return Task.FromResult(new LoginReply { IsSuccessfull = true });
            return Task.FromResult(new LoginReply { IsSuccessfull = false });
            //return base.Login(request, context);
        }

        public override Task<RegisterReply> Register(RegisterRequest request, ServerCallContext context)
        {
            RegisterReply rr = new RegisterReply { IsSuccessfull = true };
            try
            {
                Program.userDB.Add(request.Username, request.Pw);
                using (var db = new UsersContext())
                {
                    var user = new UserModel { Username = request.Username, PW = request.Pw };
                    db.users.Add(user);
                    db.SaveChanges();
                }
                //Program.realUserDB.users.Add(new EFDB.Models.UserModel { Username = request.Username, PW = request.Pw });
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
            foreach (var u in Program.userDB)
            {
                await responseStream.WriteAsync(new UserData
                {
                    Username = u.Key
                });
            }
            //return base.getOnlineUsers(request, responseStream, context);
        }
    }
}
