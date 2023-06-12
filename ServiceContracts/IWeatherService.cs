using WeatherCitiesData.Models;

namespace ServiceContracts
{
    public interface IWeatherService
    {
        List<CityWeather> GetCitiesWeatherList();
        CityWeather? GetCityWeather(string cityUniqueCode);
    }
}
