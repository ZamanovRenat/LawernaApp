using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

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

        /// <summary>
        /// Метод получения географических координат по названию населенного пункта
        /// </summary>
        /// <param name="Name">Название населенного пункта</param>
        /// <returns></returns>
        public async Task<WeatherLocation> GetWeatherByName(string name, string Api)
        {
            return await _client.GetFromJsonAsync<WeatherLocation>(
                $"/data/2.5/find?q={name}&lang=ru&appid={Api}&units=metric");
        }
    }
}

