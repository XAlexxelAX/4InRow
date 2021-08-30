﻿using EFDB.DataAccess;
using EFDB.Models;
using Grpc.Core;
using grpc4InRowService.Protos;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace grpc4InRowService.Services
{
    public class UserService : User.UserBase
    {
        //private Dictionary<Int32,String> userStreams = new Dictionary<int, String>();
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }


        public override Task<GeneralReply> Login(UserRequest request, ServerCallContext context)
        {
            try
            {
                using (var db = new UsersContext())
                {
                    UserModel userEntity = db.users.Single(user => user.Username == request.Username);
                    if (userEntity != null)
                        if (Program.onlineUsers.ContainsKey(userEntity.Id))
                            return Task.FromResult(new GeneralReply { IsSuccessfull = false });
                        else if (userEntity.PW == request.Pw)
                        {
                            //Program.onlineUsers.Add(userEntity.Id, userEntity.Username);
                            AddToOnline(new GeneralReq { Id = userEntity.Id, Username = userEntity.Username }, context);
                            return Task.FromResult(new GeneralReply { IsSuccessfull = true, Id = userEntity.Id });
                        }
                    return Task.FromResult(new GeneralReply { IsSuccessfull = false });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                    Console.WriteLine(e.InnerException.Message);
                return Task.FromResult(new GeneralReply { IsSuccessfull = false });
            }
        }

        public override Task<GeneralReply> Register(UserRequest request, ServerCallContext context)
        {
            GeneralReply rr = new GeneralReply { IsSuccessfull = true };
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
                if (e.InnerException != null)
                    Console.WriteLine(e.InnerException.Message);
                rr.IsSuccessfull = false;
            }
            return Task.FromResult(rr);
        }

        public override async Task getOnlineUsers(GeneralReq request, IServerStreamWriter<UserData> responseStream, ServerCallContext context)
        {
            foreach (var u in Program.onlineUsers)
            {
                await responseStream.WriteAsync(new UserData
                {
                    Id = u.Key,
                    Username = u.Value
                });
            }
        }

        public override Task<GeneralReply> AddToOnline(GeneralReq request, ServerCallContext context)
        {
            try
            {
                Program.onlineUsers.Add(request.Id, request.Username);
                return Task.FromResult(new GeneralReply { IsSuccessfull = true });
            }
            catch { return Task.FromResult(new GeneralReply { IsSuccessfull = false }); }
        }

        public override Task<GeneralReply> RemoveFromOnline(GeneralReq request, ServerCallContext context)
        {
            try
            {
                Program.onlineUsers.Remove(request.Id);
                return Task.FromResult(new GeneralReply { IsSuccessfull = true });
            }
            catch { return Task.FromResult(new GeneralReply { IsSuccessfull = false }); }
        }
    }
}
