
using ServiceContracts;
using WeatherCitiesData.Models;

namespace Services
{
    public class WeatherService : IWeatherService, IDisposable
    {
        #region Fields

        private List<CityWeather>? _citiesWeatherList;

        #endregion

        #region Methods

        public List<CityWeather> GetCitiesWeatherList()
        {
            _citiesWeatherList = CityWeather.GetCityWeathersData();
            return _citiesWeatherList;
        }

        public CityWeather? GetCityWeather(string cityUniqueCode)
        {
            var ChosenCity = CityWeather.GetCityByUniqueCode(cityUniqueCode);
            return ChosenCity;
        }

        public void Dispose()
        {
            
        }

        #endregion
    }
}