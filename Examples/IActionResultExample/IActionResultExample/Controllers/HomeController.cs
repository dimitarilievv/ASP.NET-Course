using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore")]
        public IActionResult Index()
        {
            //Book id should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {
            //    Response.StatusCode = 400;
              //  return Content("Book id is not supplied");
              return BadRequest("Book id is not supplied");
            }
            //Book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                // Response.StatusCode = 400;
                //  return Content("Book id can't be null or empty");
                return BadRequest("Book id can't be null or empty");
            }
            //Book id should be between 1 to 1000
            int bookId = Convert.ToInt32(Request.Query["bookid"]);
            if (bookId<=0 || bookId > 1000)
            {
              //  Response.StatusCode = 404;
                return NotFound("Book id should be between 1 to 1000");
            }
            //isloggedin should be true
            if (Convert.ToBoolean(Request.Query["isloggedin"])==false)
            {
              //  Response.StatusCode = 401;
                return Unauthorized("User must be authenticated");
            }
            // return File("/sample.pdf", "application/pdf");
            //302 - Found - RedirectToActionResult
            //return new RedirectToActionResult("Books", "Store", new { id = bookId }); //302 - Found
            //return RedirectToAction("Books", "Store", new { id = bookId });

            //301 - Moved Permanently - RedirectToActionResult
            //return new RedirectToActionResult("Books", "Store", new { }, permanent: true); //301 - Moved Permanently
            //return RedirectToActionPermanent("Books", "Store", new { id = bookId });

            //302 - Found - LocalRedirectResult
            //return new LocalRedirectResult($"store/books/{bookId}"); //302 - Found
            //return LocalRedirect($"store/books/{bookId}"); //302 - Found

            //301 - Moved Permanently - LocalRedirectResult
            return new LocalRedirectResult($"store/books/{bookId}", true); //301 - Moved Permanently
                                                                           //return LocalRedirectPermanent($"store/books/{bookId}"); //301 - Moved Permanently

            //return Redirect($"store/books/{bookId}"); //302 - Found
            //return RedirectPermanent($"store/books/{bookId}"); //301 - Moved Permanently

        }
    }
}
