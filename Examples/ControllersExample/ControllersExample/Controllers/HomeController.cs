using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("home")]
        public ContentResult Index()
        {
            /* return new ContentResult()
             {
                 Content = "Hello from Index",
                 ContentType = "text/plain"
             };*/

            // return Content("Hello from Index", "text/plain");

            return Content("<h1>Welcome</h1><h2>Hello from Index</h2>", "text/html");

        }

        [Route("about")]
        public string About()
        {
            return "Hello from About";
        }
        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello from Contact";
        }
        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Dimitar",
                LastName = "Iliev",
                Age = 21
            };
            return Json(person);
            //return new JsonResult(person);
            //return "{\"key\":\"value\"}";
        }
        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            return File("/sample.pdf", "application/pdf");
            //return new VirtualFileResult("/sample.pdf", "application/pdf");
        }
        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            return PhysicalFile(@"C:\Users\dimit\Desktop\AspCourse\sample.pdf", "application/pdf");
            //return new PhysicalFileResult(@"C:\Users\dimit\Desktop\AspCourse\sample.pdf", "application/pdf");
        }
        [Route("file-download3")]
        public IActionResult FileDownload3()
      //  public FileContentResult FileDownload3()
        {
           byte[] bytes= System.IO.File.ReadAllBytes(@"C:\Users\dimit\Desktop\AspCourse\sample.pdf");
            return File(bytes, "application/pdf");
            //return new FileContentResult(bytes,"application/pdf");
        }
    }
}
