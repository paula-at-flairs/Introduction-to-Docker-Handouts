using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using WhalesAPI.Models;

namespace WhalesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var sp = host.Services.CreateScope().ServiceProvider;
            var dbContext = sp.GetRequiredService<AppDbContext>();

            TryNTimes(() => dbContext.Database.EnsureCreated(), 60, "Ensure Database Created");

            host.Run();
        }

        public static void TryNTimes(Action action, int retries, string actionTitle)
        {
            var tries = retries;
            while (true)
            {
                try
                {
                    action();
                    break;
                }
                catch
                {
                    if (--tries == 0)
                        throw;

                    Console.WriteLine($"Couldn't process your action: {actionTitle}, retrying after one seconds, retries left: {tries}");

                    Thread.Sleep(1000);
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
