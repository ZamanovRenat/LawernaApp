using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            
        }


        static async Task Main(string[] args)
        {
            using var host = hosting;
            await host.StartAsync();

            await host.StopAsync();

            string path = @"C:\Programs on C#\LawernaApp\ApiKey.txt";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine($"http://api.openweathermap.org/data/2.5/weather?id=524901&appid={line}&lang=ru");
                }
            }
        }
    }
}

/*http://api.openweathermap.org/data/2.5/weather?id=524901&appid={API key}&lang={lang}*/
/*api.openweathermap.org/data/2.5/weather?q={city name}&appid={API key}*/