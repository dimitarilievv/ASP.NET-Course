using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using BankAppUsingControllers.Models;

namespace BankAppUsingControllers.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the Best Bank");
        }
        [Route("account-details")]
        public IActionResult Details()
        {
            Account account = new Account()
            {
                accountNumber = 1001,
                accountHolderName = "Example Name",
                currentBalance = 5000
            };
            return Json(account);
        }
        [Route("account-statement")]
        public IActionResult Statement()
        {
            return File("/sample.pdf", "application/pdf");
        }
        [Route("get-current-balance/{accountNumber:int?}")]
        public IActionResult GetBalance()
        {
           // object accountNumberObj;
            /*   if (HttpContext.Request.RouteValues.TryGetValue("accountNumber", out accountNumberObj) && accountNumberObj is string accountNumber)
               {
                   if (string.IsNullOrEmpty(accountNumber))
                   {
                       return NotFound("Account Number should be supplied\n");
                   }
                   int accountNumberInt = Convert.ToInt32(accountNumber);
                   var bankAccount = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };
                   if (accountNumberInt != 1001)
                   {
                       return BadRequest("Account Number should be 1001");
                   }
                   return Content(bankAccount.currentBalance.ToString());
               }
               else
               {
                   return NotFound("Account Number should be supplied\n");
               }
            */
            if (!Request.RouteValues.ContainsKey("accountNumber"))
            {
                return NotFound("account number should be supplied");
            }
            int accountNum = Convert.ToInt16(Request.RouteValues["accountNumber"]);
            if (accountNum != 1001)
            {
                return BadRequest("account number must be 1001");
            }
            var accDetail = new
            {
                accountNumber = 1001,
                accountHolderName = "example name",
                currentBalance = 5000,
            };
            return Content(Convert.ToString(accDetail.currentBalance), "text/plain");

    }
    }

}

