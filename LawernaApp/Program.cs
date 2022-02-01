using System;
using System.IO;
using System.Threading.Tasks;

namespace LawernaApp
{
    class Program
    {
        static void Main(string[] args)
        {
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