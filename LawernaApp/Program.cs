using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenWeatherMap;

namespace LawernaApp
{
    class Program
    {
        private static IHost _hosting;

        public static IHost hosting => _hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static IServiceProvider Services => hosting.Services;
        /// <summary>
        /// Построитель хоста
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices);
        /// <summary>
        /// Метод конфигурирования сервисов
        /// </summary>
        /// <param name="host"></param>
        /// <param name="services"></param>
        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddHttpClient<OpenWeatherMapClient>(client => client.BaseAddress = new Uri(host.Configuration["Openweathermap"]));
        }


        static async Task Main(string[] args)
        {
            using var host = hosting;
            await host.StartAsync();

            var weather = Services.GetRequiredService<OpenWeatherMapClient>();

            string path = @"C:\Programs on C#\LawernaApp\ApiKey.txt";
            string line = System.IO.File.ReadAllText(path);

            Console.WriteLine("Введите название города");
            string city = Console.ReadLine();

            var location = await weather.GetWeatherByName(city, line);

            await host.StopAsync();
        }
    }
}
