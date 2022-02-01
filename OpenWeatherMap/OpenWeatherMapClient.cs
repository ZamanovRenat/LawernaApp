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
        public async Task<WeatherLocation> GetLocationByName(int id, string Api)
        {
            return await _client.GetFromJsonAsync<WeatherLocation>(
                $"http://api.openweathermap.org/data/2.5/weather?id={id}&lang=ru&appid={Api}");
        }
    }
}
