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
            userStreams.Add(1,"Shahar Blank");
        }

        public override Task<LoginReply> Login(LoginRequest request, ServerCallContext context)
        {
            return base.Login(request, context);
        }

        public override Task<RegisterReply> Register(RegisterRequest request, ServerCallContext context)
        {
            return base.Register(request, context);
        }

        public override async Task getOnlineUsers(Req request, IServerStreamWriter<UserData> responseStream, ServerCallContext context)
        {
            foreach (var userStream in userStreams)
            {
                await responseStream.WriteAsync(new UserData
                {
                    Id = userStream.Key,
                    User = userStream.Value
                });
            }
            //return base.getOnlineUsers(request, responseStream, context);
        }
    }
}
