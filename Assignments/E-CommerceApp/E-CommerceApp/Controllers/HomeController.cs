using E_CommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("/order")]
        public IActionResult Index([Bind(nameof(Order.OrderDate), nameof(Order.InvoicePrice), nameof(Order.Products))] Order order)
        {
            if(!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(x => x.Errors).Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }
            Random random = new Random();
            order.OrderNo= random.Next(1, 100000);
            return Json(new { orderNumber= order.OrderNo });
        }
    }
}
