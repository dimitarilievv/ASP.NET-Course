using Microsoft.AspNetCore.Mvc;
using PartialViewsExample.Models;

namespace PartialViewsExample.Controllers
{
	public class HomeController : Controller
	{
		[Route("/")]
		public IActionResult Index()
		{
			//ViewData["ListTitle"] = "Cities";
			//ViewData["ListItems"]=new List<string>()
			//{
			//    "Paris",
			//    "New York",
			//    "London",
			//    "Rome"
			//};
			return View();
		}
		[Route("about")]
		public IActionResult About()
		{
			return View();
		}
		[Route("programming-languages")]
		public IActionResult ProgrammingLanguages()
		{
			ListModel listModel = new ListModel()
			{
				ListTitle = "Programming Languages",
				ListItems = new List<string>()
				{
				"Java",
				"C",
				"C#",
				"C++",
				"Python"
				}
			};
			return PartialView("_ListPartialView", listModel);
		}
	}
}
