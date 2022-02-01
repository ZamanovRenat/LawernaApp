namespace OpenWeatherMap
{
    /*
     * Класс определения id местоположения
     * Документация по https://openweathermap.org/api/geocoding-api
     * Пример для города Казань
     *     {
        "id": 551487,
        "name": "Kazan",
        "state": "",
        "country": "RU",
        "coord": {
            "lon": 49.122139,
            "lat": 55.788738
        }
    },
     */
    public class WeatherLocation
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public (double lon, double lat) coord { get; set; }
    }
}
