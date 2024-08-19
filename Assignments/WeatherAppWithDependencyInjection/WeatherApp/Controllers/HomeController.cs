using Microsoft.AspNetCore.Mvc;
using Models;
using ServiceContracts;

namespace WeatherApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IWeatherService _weatherService;
		public HomeController(IWeatherService weatherService)
		{
			_weatherService = weatherService;
		}

		[Route("/")]
		public IActionResult ALlCities()
		{
			var cities = _weatherService.GetWeatherDetails();
			return View("AllCities", cities);
		}
		[Route("/weather/{cityCode?}")]
		public IActionResult Details(string? cityCode)
		{
			if (cityCode == null)
				return Content("CityCode can't be null");
			CityWeather? matchingCity = _weatherService.GetWeatherByCityCode(cityCode);
			return View(matchingCity);
		}
	}
}
