using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
	public class HomeController : Controller
	{
		private List<CityWeather> cities = new List<CityWeather>()
			{
				new CityWeather(){CityUniqueCode = "LDN", CityName = "London", DateAndTime = DateTime.Parse("2030-01-01 8:00"),  TemperatureFahrenheit = 33},
				new CityWeather(){CityUniqueCode = "NYC", CityName = "New York", DateAndTime = DateTime.Parse("2030-01-01 3:00"),  TemperatureFahrenheit = 60},
				new CityWeather(){CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = DateTime.Parse("2030-01-01 9:00"),  TemperatureFahrenheit = 82}
			};
		[Route("/")]
		public IActionResult ALlCities()
		{
			ViewBag.appTitle = "Weather";
			return View("AllCities", cities);
		}
		[Route("/weather/{cityCode?}")]
		public IActionResult Details(string? cityCode)
		{
			if (cityCode == null)
				return Content("CityCode can't be null");
			ViewBag.appTitle = "Weather";
			CityWeather? matchingCity = cities.Where(c => c.CityUniqueCode == cityCode).FirstOrDefault();
			return View(matchingCity);
		}
	}
}
