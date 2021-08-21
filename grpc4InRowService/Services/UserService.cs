using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grpc4InRowService.Services
{
    public class UserService : User.UserBase
    {
        private readonly ILogger<UserService> logger;
        private Dictionary<Int32, IServerStreamWriter<Object>> userStreams;

        public UserService(ILogger<UserService> logger)
        {
            this.logger = logger;
        }

        public override Task<LoginReply> Login(LoginRequest request, ServerCallContext context)
        {
            //look up in db for user and populate login reply
            LoginReply loginReply = new LoginReply();
            loginReply.IsSuccessfull = true;
            return Task.FromResult(loginReply);
        }

        public override Task<RegisterReply> Register(RegisterRequest request, ServerCallContext context)
        {
            //look up in db for user if exists and return answer accordingly
            RegisterReply registerReply = new RegisterReply();
            return Task.FromResult(registerReply);
        }
    }
}
