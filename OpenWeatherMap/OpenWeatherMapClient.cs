using System.Net.Http;

namespace OpenWeatherMap
{
    public class OpenWeatherMapClient
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Передача в класс объект класса HttpClient
        /// </summary>
        /// <param name="client">Объект класса HttpClient</param>
        public OpenWeatherMapClient(HttpClient client) => _client = client;
    }
}
