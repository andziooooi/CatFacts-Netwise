using CatFacts_Netwise.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CatFacts_Netwise
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var app = host.Services.GetRequiredService<ICatFactsApp>();
            await app.RunApp();
        }
        static IHostBuilder CreateHostBuilder(string[] arg) =>
            Host.CreateDefaultBuilder(arg).ConfigureLogging(logging =>
            {
                //Add filter to console for clarity
                logging.AddFilter("System.Net.Http.HttpClient", LogLevel.Warning);
            }).ConfigureServices((contex, services) =>
            {
                services.AddHttpClient<ICatFactsService, CatFactsService>(client =>
                {
                    //Configure base adress for API requests
                    client.BaseAddress = new Uri("https://catfact.ninja/");

                    //Configure timeout to prevent infinite hanging request
                    client.Timeout = TimeSpan.FromSeconds(30);
                });
                services.AddTransient<ICatFactsApp, CatFactsApp>();
                services.AddSingleton<IFileService,FileService>();
            });
    }
}