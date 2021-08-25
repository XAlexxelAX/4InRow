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
    public class GameService : Games.GamesBase
    {
        private readonly ILogger<GameService> _logger;
        public GameService(ILogger<GameService> logger)
        {
            _logger = logger;
        }

        public override Task<CheckReply> CheckForGame(Check request, ServerCallContext context)
        {
            if (request.Id1 != -1 && Program.gameRequests.ContainsKey(request.Id1))
            {
                if (Program.gameRequests[request.Id1].Item2 == AnswerCode.Unanswered)
                {
                    int gameReq = Program.gameRequests[request.Id1].Item1;
                    return Task.FromResult(new CheckReply { Answer = true, Offeringid = gameReq, Status = AnswerCode.Unanswered });
                }
                else
                    return Task.FromResult(new CheckReply { Answer = true, Status = Program.gameRequests[request.Id1].Item2 });
            }
            return Task.FromResult(new CheckReply { Answer = false });
        }
        public override Task<GameReply> OfferGame(GameRequest request, ServerCallContext context)
        {
            try
            {
                if (Program.gameRequests.ContainsKey(request.OpponentID))
                    Program.gameRequests[request.OpponentID] = (Program.gameRequests[request.OpponentID].Item1, request.Answer);
                else
                    Program.gameRequests.Add(request.OpponentID, (request.MyId, AnswerCode.Unanswered));
                return Task.FromResult(new GameReply { Answer = true });
            }
            catch
            {
                return Task.FromResult(new GameReply { Answer = false });
            }
        }

        public override Task<Reply> CheckMove(Check request, ServerCallContext context)
        {
            if (Program.ongoingGames.ContainsKey((request.Id1, request.Id2)) || Program.ongoingGames.ContainsKey((request.Id2, request.Id2)))
            {
                try
                {
                    return Task.FromResult(new Reply
                    {
                        Answer = true,
                        Move = new Move
                        {
                            Id = Program.ongoingGames[(request.Id1, request.Id2)].Item2[-1].Item1,
                            Move_ = Program.ongoingGames[(request.Id1, request.Id2)].Item2[-1].Item2
                        }
                    });
                }
                catch
                {
                    return Task.FromResult(new Reply
                    {
                        Answer = true,
                        Move = new Move
                        {
                            Id = Program.ongoingGames[(request.Id2, request.Id1)].Item2[-1].Item1,
                            Move_ = Program.ongoingGames[(request.Id2, request.Id1)].Item2[-1].Item2
                        }
                    });
                }
            }
            return Task.FromResult(new Reply { Answer = false });
        }

        public override Task<Reply> MakeMove(MoveRequest request, ServerCallContext context)
        {
            if (!(Program.ongoingGames.ContainsKey((request.MyId, request.OpponentID)) || Program.ongoingGames.ContainsKey((request.OpponentID, request.MyId))))
            {
                Program.ongoingGames.Add((request.MyId, request.OpponentID), (new System.DateTime(), new List<(int, int)>()));
                Program.gameRequests.Remove(request.MyId);
            }
            try
            {
                try
                {
                    Program.ongoingGames[(request.MyId, request.OpponentID)].Item2.Add((request.MyId, request.Move));
                }
                catch
                {
                    Program.ongoingGames[(request.OpponentID, request.MyId)].Item2.Add((request.MyId, request.Move));
                    return Task.FromResult(new Reply { Answer = true });
                }
                return Task.FromResult(new Reply { Answer = true });
            }
            catch
            {
                return Task.FromResult(new Reply { Answer = false });
            }
        }

        public override Task<Reply> UpdateScore(Score request, ServerCallContext context)
        {
            using (var db = new UsersContext())
            {
                UserModel userEntity = db.users.Single(user => user.Id == request.Id);
                if (userEntity != null)
                {
                    userEntity.Score += request.Score_;
                    userEntity.GamesPlayed++;
                    if (request.Won)
                        userEntity.GamesWon++;
                }
                db.SaveChanges();
            }
            return base.UpdateScore(request, context);
        }
    }
}
