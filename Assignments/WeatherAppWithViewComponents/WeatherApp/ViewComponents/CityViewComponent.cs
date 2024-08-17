using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.ViewComponents
{
	public class CityViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(CityWeather city)
		{
			ViewBag.CityCssClass = GetCssColor(city.TemperatureFahrenheit);
			return View(city);
		}
		private string GetCssColor(int TemperatureFahrenheit)
		{
			switch (TemperatureFahrenheit)
			{
				case < 44:
					return "blue-back";
				case >= 44 and < 75:
					return "green-back";
				case >= 75:
					return "orange-back";
			};
		}
	}
}
