using EFDB.DataAccess;
using EFDB.Models;
using Grpc.Core;
using grpc4InRowService.Protos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace grpc4InRowService.Services
{
    public class UserService : User.UserBase
    {
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
                    UserModel userEntity = db.users.Single(user => user.Username == request.Username);//gets user reference from db by username(the primary key)
                    if (userEntity != null) {//if found user in db
                        if (Program.onlineUsers.ContainsKey(userEntity.Id))// if user already logged in
                            throw new Exception("User already logged in");
                        else if (userEntity.PW == request.Pw)//else checks if password matches the db
                        {
                            AddToOnline(new GeneralReq { Id = userEntity.Id, Username = userEntity.Username }, context);
                            return Task.FromResult(new GeneralReply { IsSuccessfull = true, Id = userEntity.Id });
                        }
                        else throw new Exception("Wrong password");
                    }
                    return Task.FromResult(new GeneralReply { IsSuccessfull = false });
                }
            }
            catch (InvalidOperationException e)
            {
                return Task.FromResult(new GeneralReply { IsSuccessfull = false, Error = "User doesn't exists" });//if user is already logged in returns a error messege
            }
            catch (Exception e)
            {
                return Task.FromResult(new GeneralReply { IsSuccessfull = false, Error = e.Message });//if user is already logged in returns a error messege
            }
        }

        public override Task<GeneralReply> Register(UserRequest request, ServerCallContext context)
        {
            GeneralReply rr = new GeneralReply { IsSuccessfull = true };
            try
            {
                using (var db = new UsersContext())
                {
                    var user = new UserModel { Username = request.Username, PW = request.Pw };// creates new user model to be added to db
                    db.users.Add(user);
                    db.SaveChanges();
                }
            }
            catch (DbUpdateException e)// if user by the same primary key(username) already in db, exception is thrown
            {
                rr.IsSuccessfull = false;
                rr.Error = "A user with this name exists already.";
            }
            return Task.FromResult(rr);
        }

        public override async Task getOnlineUsers(GeneralReq request, IServerStreamWriter<UserData> responseStream, ServerCallContext context)
        {
            foreach (var u in Program.onlineUsers)// writes async all users from onlineusers dict
            {
                await responseStream.WriteAsync(new UserData
                {
                    Id = u.Key,
                    Username = u.Value
                });
            }
        }

        public override Task<GeneralReply> AddToOnline(GeneralReq request, ServerCallContext context)//adds a user to onlineusers dict
        {
            try
            {
                Program.onlineUsers.Add(request.Id, request.Username);
                return Task.FromResult(new GeneralReply { IsSuccessfull = true });
            }
            catch { return Task.FromResult(new GeneralReply { IsSuccessfull = false }); }
        }

        public override Task<GeneralReply> RemoveFromOnline(GeneralReq request, ServerCallContext context)// removes a user from onlineusers dict
        {
            try
            {
                Program.onlineUsers.Remove(request.Id);
                return Task.FromResult(new GeneralReply { IsSuccessfull = true });
            }
            catch { return Task.FromResult(new GeneralReply { IsSuccessfull = false, Error = "User was not found in online users." }); }// if user wasn't in onlineuser dict returns a message
        }
    }
}
