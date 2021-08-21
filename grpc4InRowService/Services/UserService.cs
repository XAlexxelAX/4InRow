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
        private Dictionary<Int32,IServerStreamWriter<Object>> userStreams = new Dictionary<int, IServerStreamWriter<object>>();
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<LoginReply> Login(LoginRequest request, ServerCallContext context)
        {
            return base.Login(request, context);
        }

        public override Task getOnlineUsers(Req request, IServerStreamWriter<UserData> responseStream, ServerCallContext context)
        {
            foreach (var userStream in userStreams)
            {
                responseStream.WriteAsync(new UserData
                {
                    Id = userStream.Key,
                    User = ""
                });
            }
            return base.getOnlineUsers(request, responseStream, context);
        }
    }
}
