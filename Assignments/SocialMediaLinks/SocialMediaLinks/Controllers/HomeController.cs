using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace SocialMediaLinks.Controllers
{
	public class HomeController : Controller
	{
		private readonly IOptions<SocialMediaLinksOptions> _socialMediaLinksOptions;
		public HomeController(IOptions<SocialMediaLinksOptions> socialMediaLinksOptions)
		{
			_socialMediaLinksOptions = socialMediaLinksOptions;
		}
		[Route("/")]
		public IActionResult Index()
		{
			ViewBag.SocialMediaLinks = _socialMediaLinksOptions.Value;
			return View();
		}
	}
}
