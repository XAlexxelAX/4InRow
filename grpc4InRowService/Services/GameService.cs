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
            try
            {
                if (Program.gameRequests.ContainsKey(request.MyId))//some player checks if someone offered him a game, receives back Answer if someone offered and if so, gets the offering ID
                    return Task.FromResult(new CheckReply { Answer = true, Offeringid = Program.gameRequests[request.MyId].Item1 });
                else if (Program.gameRequests.ContainsKey(request.OpponentID))//offering player checks if request was answered
                    return Task.FromResult(new CheckReply { Answer = true, Status = Program.gameRequests[request.OpponentID].Item2 });
                else
                    return Task.FromResult(new CheckReply { Answer = false });
            }
            catch
            {
                return Task.FromResult(new CheckReply { Answer = false });
            }
        }

        public override Task<GameReply> OfferGame(GameRequest request, ServerCallContext context)
        {
            try
            {
                if (Program.gameRequests.ContainsKey(request.OpponentID))
                {
                    if (Program.gameRequests[request.OpponentID].Item1 != request.MyId)//Can't offer game because someone already offered him a game.
                        return Task.FromResult(new GameReply { Answer = false });
                    else
                    {
                        Program.gameRequests[request.OpponentID] = (request.MyId, request.Answer);//Offered player answers the game request
                        return Task.FromResult(new GameReply { Answer = true });
                    }
                }
                Program.gameRequests.Add(request.OpponentID, (request.MyId, AnswerCode.Unanswered));//new offered game
                return Task.FromResult(new GameReply { Answer = true });
            }
            catch
            {
                return Task.FromResult(new GameReply { Answer = false });//some error with offering
            }
        }

        public override Task<Reply> CheckMove(MoveCheck request, ServerCallContext context)
        {
            if (Program.ongoingGames.ContainsKey((request.InitiatorID, request.InitiatedID)))
            {
                try
                {
                    return Task.FromResult(new Reply
                    {
                        Answer = true,
                        Move = new Move
                        {
                            Id = Program.ongoingGames[(request.InitiatorID, request.InitiatedID)].Item2.Last().Item1,
                            Move_ = Program.ongoingGames[(request.InitiatorID, request.InitiatedID)].Item2.Last().Item2,
                            Index = Program.ongoingGames[(request.InitiatorID, request.InitiatedID)].Item2.Count - 1
                        }
                    });
                }
                catch
                {
                    return Task.FromResult(new Reply { Answer = false });
                }
            }
            return Task.FromResult(new Reply { Answer = false });
        }

        public override Task<Reply> MakeMove(MoveRequest request, ServerCallContext context)
        {
            if (!(Program.ongoingGames.ContainsKey((request.InitiatorID, request.InitiatedID))))//If it's a new game and isn't in ongoing game, a new game added, key is a tuple of (game initiator,game accepter)
            {
                Program.ongoingGames.Add((request.InitiatorID, request.InitiatedID), (new System.DateTime(), new List<(int, int)>()));
                Program.gameRequests.Remove(request.InitiatedID);
            }
            try
            {
                if (Program.ongoingGames[(request.InitiatorID, request.InitiatedID)].Item2.Count == 0)
                    Program.ongoingGames[(request.InitiatorID, request.InitiatedID)].Item2.Add((request.InitiatedID, request.Move));
                else if (Program.ongoingGames[(request.InitiatorID, request.InitiatedID)].Item2.Last().Item1 == request.InitiatedID)
                    Program.ongoingGames[(request.InitiatorID, request.InitiatedID)].Item2.Add((request.InitiatorID, request.Move));
                else
                    Program.ongoingGames[(request.InitiatorID, request.InitiatedID)].Item2.Add((request.InitiatedID, request.Move));
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
                UserModel userEntity = db.users.Single(user => user.Id == request.Key1);
                if (userEntity != null)
                {
                    userEntity.Score += request.Score1;
                    userEntity.GamesPlayed++;
                    if (request.Won == 1)
                        userEntity.GamesWon++;
                }
                userEntity = db.users.Single(user => user.Id == request.Key2);
                if (userEntity != null)
                {
                    userEntity.Score += request.Score2;
                    userEntity.GamesPlayed++;
                    if (request.Won == 2)
                        userEntity.GamesWon++;
                }
                if (Program.ongoingGames.ContainsKey((request.Key1, request.Key2)))
                {
                    db.games.Add(new Game
                    {
                        FinishTime = Program.ongoingGames[(request.Key1, request.Key2)].Item1,
                        Player1 = request.Key1,
                        Player2 = request.Key2,
                        Player1Score = request.Score1,
                        Player2Score = request.Score2,
                        WinnerId = request.Won
                    });
                    Program.ongoingGames.Remove((request.Key1, request.Key2));
                }
                db.SaveChanges();
            }
            return Task.FromResult(new Reply { Answer = true });
        }
    }
}
