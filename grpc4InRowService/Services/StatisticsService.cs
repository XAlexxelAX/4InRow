﻿using EFDB.DataAccess;
using Grpc.Core;
using grpc4InRowService.Protos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grpc4InRowService.Services
{
    public class StatisticsService : Statistics.StatisticsBase
    {
        private ILogger<StatisticsService> _logger;

        public StatisticsService(ILogger<StatisticsService> logger)
        {
            _logger = logger;
        }

        public override async Task getAllUsersStats(StatsRequest request, IServerStreamWriter<UserStats> responseStream, ServerCallContext context)
        {
            using(var db = new UsersContext())
                foreach(var user in db.users)
                    await responseStream.WriteAsync(new UserStats
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Games = user.GamesPlayed,
                        Wins = user.GamesWon,
                        Score = user.Score
                    });
            //return base.getAllUsersStats(request, responseStream, context);
        }

        public override async Task getFinisedGames(StatsRequest request, IServerStreamWriter<GameStats> responseStream, ServerCallContext context)
        {
            using(var db = new UsersContext())
                foreach (var game in db.games)
                    await responseStream.WriteAsync(new GameStats
                    {
                        Id1 = game.Player1,
                        Id2 = game.Player2,
                        User1 = db.users.Single(user => user.Id == game.Player1).Username,
                        User2 = db.users.Single(user => user.Id == game.Player2).Username,
                        Winner = game.WinnerId,
                        Date = new Protos.DateTime
                        {
                            Hour = game.FinishTime.Hour,
                            Minute = game.FinishTime.Minute,
                            Day = game.FinishTime.Day,
                            Month = game.FinishTime.Month,
                            Year = game.FinishTime.Year
                        }
                    });
        }

        public override async Task getOngoingGames(StatsRequest request, IServerStreamWriter<GameStats> responseStream, ServerCallContext context)
        {
            using (var db = new UsersContext())
                foreach (var game in Program.ongoingGames)
                    await responseStream.WriteAsync(new GameStats
                    {
                        Id1 = game.Key.Item1,
                        Id2 = game.Key.Item2,
                        User1 = db.users.Single(user => user.Id == game.Key.Item1).Username,
                        User2 = db.users.Single(user => user.Id == game.Key.Item2).Username,
                        Date = new Protos.DateTime
                        {
                            Hour = game.Value.Item1.Hour,
                            Minute = game.Value.Item1.Minute,
                            Day = game.Value.Item1.Day,
                            Month = game.Value.Item1.Month,
                            Year = game.Value.Item1.Year
                        }
                    });
        }

        public override async Task getUsersIntersection(StatsRequest request, IServerStreamWriter<GameStats> responseStream, ServerCallContext context)
        {
            using (var db = new UsersContext())
                foreach (var game in db.games.Where(g => g.Player1 == request.Id1 && g.Player2 == request.Id2 || g.Player1 == request.Id2 && g.Player2 == request.Id1))
                    await responseStream.WriteAsync(new GameStats
                    {
                        Id1 = game.Player1,
                        Id2 = game.Player2,
                        User1 = db.users.Single(user => user.Id == game.Player1).Username,
                        User2 = db.users.Single(user => user.Id == game.Player2).Username,
                        Winner = game.WinnerId,
                        Date = new Protos.DateTime
                        {
                            Hour = game.FinishTime.Hour,
                            Minute = game.FinishTime.Minute,
                            Day = game.FinishTime.Day,
                            Month = game.FinishTime.Month,
                            Year = game.FinishTime.Year
                        }
                    });
        }

        public override Task<UserStats> getUserStats(StatsRequest request, ServerCallContext context)
        {
            using (var db = new UsersContext())
            {
                var user = db.users.Single(u => u.Id == request.Id1);
                return Task.FromResult(new UserStats
                {
                    Id = user.Id,
                    Username = user.Username,
                    Games = user.GamesPlayed,
                    Wins = user.GamesWon,
                    Score = user.Score
                });
            }
        }
    }
}