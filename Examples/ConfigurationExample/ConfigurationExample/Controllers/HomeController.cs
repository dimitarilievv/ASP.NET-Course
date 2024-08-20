using Microsoft.AspNetCore.Mvc;

namespace ConfigurationExample.Controllers
{
	public class HomeController : Controller
	{
		//private field
		private readonly IConfiguration _configuration;
		//constructor
		public HomeController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		[Route("/")]
		public IActionResult Index()
		{
			ViewBag.MyKey = _configuration["MyKey"];
			ViewBag.MyAPIKey = _configuration.GetValue("MyAPIKey","the default");
			//ViewBag.ClientID = _configuration["weatherapi:ClientID"]; OR
			//IConfigurationSection weatherapiSection = _configuration.GetSection("weatherapi");
			//ViewBag.ClientID =weatherapiSection["ClientID"];

			//ViewBag.ClientSecret = _configuration.GetValue("weatherapi:ClientSecret","default client secret"); or
			//ViewBag.ClientSecret = weatherapiSection["ClientSecret"];

			//with model options
			//with get loads conf values into a new options object
			//WeatherApiOptions options = _configuration.GetSection("weatherapi").Get<WeatherApiOptions>();
			//with bind loads conf values into a existing options object
			WeatherApiOptions options= new WeatherApiOptions();
			_configuration.GetSection("weatherapi").Bind(options);
			ViewBag.ClientID=options.ClientID;
			ViewBag.ClientSecret=options.ClientSecret;

			return View();
		}
	}
}
