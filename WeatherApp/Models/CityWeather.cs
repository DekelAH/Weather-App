using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models
{
    public class CityWeather
    {
        #region Properties

        [Required(ErrorMessage = "'{0}' Can't be null or empty, please enter a valid code.")]
        [DisplayName("City Unique Code")]
        public string? CityUniqueCode { get; set; }
        public string? CityName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? TempCelsius { get; set; }

        #endregion

        #region Methods

        public static CityWeather? GetCityByUniqueCode(string uniqueCode)
        {
            var cities = GetCityWeathers();
            var matchedCityWeather = cities.Where(temp => temp.CityUniqueCode == uniqueCode).FirstOrDefault();

            return matchedCityWeather;
        }

        public static List<CityWeather> GetCityWeathers()
        {
            List<CityWeather> cityWeathers = new()
            {
                new CityWeather() {CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TempCelsius = 6},
                new CityWeather() {CityUniqueCode = "TLV", CityName = "Tel-Aviv", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TempCelsius = 30},
                new CityWeather() {CityUniqueCode = "NYC", CityName = "New-York-City", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TempCelsius = 8},
            };

            return cityWeathers;
        }

        #endregion
    }
}
