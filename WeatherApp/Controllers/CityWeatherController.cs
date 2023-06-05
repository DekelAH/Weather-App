using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Home()
        {
            ViewData["appTitle"] = "WeatherApp";
            var citiesWeather = CityWeather.GetCityWeathers();
            return View(citiesWeather);
        }

        [Route("/details/{cityCode}")]
        public IActionResult Details(string cityCode)
        {
            var matchedCity = CityWeather.GetCityByUniqueCode(cityCode);
            return View(matchedCity);
        }
    }
}
