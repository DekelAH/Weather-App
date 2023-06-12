using Autofac;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private readonly IWeatherService _weatherService;
        private readonly ILifetimeScope _lifetimeScope;

        #endregion

        #region Ctors

        public HomeController(IWeatherService weatherService, ILifetimeScope lifetimeScope)
        {
            _weatherService = weatherService;
            _lifetimeScope = lifetimeScope;
        }

        #endregion

        [Route("home")]
        [Route("/")]
        public IActionResult Home()
        {
            ViewData["appTitle"] = "WeatherApp";
            var citiesWeather = _weatherService.GetCitiesWeatherList();
            return View(citiesWeather);
        }

        [Route("/details/{cityCode?}")]
        public IActionResult Details(string cityCode)
        {
            var matchedCity = _weatherService.GetCityWeather(cityCode);
            if (string.IsNullOrEmpty(cityCode) || int.TryParse(cityCode, out int result))
            {
                StatusCode(400);
                return View();
            }
            else if(matchedCity == null)
            {
                StatusCode(400);
                return View();
            }

            return View(matchedCity);
        }
    }
}
