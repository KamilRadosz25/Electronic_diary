using Diary.Database;
using Diary.Manager;
using Diary.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Diary
{
    internal class Program
    {
        private static Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            var consoleManager = new ConsoleManager(host.Services.GetService<IMarkRepository>(), host.Services.GetService<IStudentRepository>());
            consoleManager.DisplayWelcomeText();

            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            services.AddSingleton<IDatabaseConnection, DatabaseConnection>()
                    .AddSingleton<IMarkRepository, MarkRepository>()
                    .AddSingleton<IStudentRepository, StudentRepository>());
    }
}