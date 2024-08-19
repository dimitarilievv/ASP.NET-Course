using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
		[Route("/")]
		public IActionResult Index()
        {
			ViewData["appTitle"] = "ASP.NET Core Demo App";

			List<Person> people = new List<Person>()
			{
				new Person(){Name = "John",DateOfBirth = Convert.ToDateTime("2000-07-01"),PersonGender = Gender.Male},
				new Person(){Name = "Anna",DateOfBirth = Convert.ToDateTime("1989-07-01"),PersonGender = Gender.Female},
				new Person(){Name = "Susa",DateOfBirth = Convert.ToDateTime("2005-07-01"),PersonGender = Gender.Other}
			};
				//ViewData["peopleViewData"] = people;
				//ViewBag.People = people;
				return View("Index",people); //Views/Home/Index.cshtml
        }
		[Route("person-details/{name}")]
		public IActionResult Details(string? name) 
		{
			if (name == null)
				return Content("Person name can't be null");
			List<Person> people = new List<Person>()
			{
				new Person(){Name = "John",DateOfBirth = Convert.ToDateTime("2000-07-01"),PersonGender = Gender.Male},
				new Person(){Name = "Anna",DateOfBirth = Convert.ToDateTime("1989-07-01"),PersonGender = Gender.Female},
				new Person(){Name = "Susa",DateOfBirth = Convert.ToDateTime("2005-07-01"),PersonGender = Gender.Other}
			};
			Person? mathcingPerson=people.Where(temp=>temp.Name== name).FirstOrDefault();
			return View(mathcingPerson);//Views/Home/Details
		}
		[Route("person-with-product")]
		public IActionResult PersonAndProduct()
		{
			Person person= new Person()
			{
				Name = "Mario",
				DateOfBirth = Convert.ToDateTime("2000-07-01"),
				PersonGender = Gender.Male
			};
			Product product = new Product()
			{
				ProductId=1,
				ProductName="Air Conditioner"
			};
			PersonAndProductWrapper personAndProductWrapper = new PersonAndProductWrapper()
			{
				PersonData= person,
				ProductData= product
			};
			return View(personAndProductWrapper);
		}
		[Route("home/all-products")]
		public IActionResult All()
		{
			return View();//Views/Home/All.cshtml or Views/Shared/All.cshtml
		}
	}
}
