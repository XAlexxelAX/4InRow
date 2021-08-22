
using grpc4InRowService.Protos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace grpc4InRowService
{
    public class Program
    {
        public static Dictionary<Int32, String> onlineUsers = new Dictionary<Int32, String>();//key = id, value = username
        public static Dictionary<Int32, Int32> gameRequests = new Dictionary<Int32, Int32>();//key = id of offered user, value: item1 = offering user, item2 = answer
        public static Dictionary<(Int32, Int32), (System.DateTime, List<(Int32,Int32)>)> ongoingGames = new Dictionary<(Int32, Int32), (System.DateTime, List<(Int32, Int32)>)>();
        //public static Dictionary<Int32, (Int32, Int32)> moves = new Dictionary<int, (int, Int32)>();//key = next turn's id, value: item1 = last turn's id, item2 = move
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
