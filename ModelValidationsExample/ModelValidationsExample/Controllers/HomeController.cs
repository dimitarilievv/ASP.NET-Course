using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using ModelValidationsExample.CustomModelBinder;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index([ModelBinder(BinderType =typeof(PersonModelBinder))]Person person)
        //[Bind(nameof(Person.PersonName),nameof(Person.Email),nameof(Person.Password),nameof(Person.ConfirmPassword))]Person person)
        {
            if (!ModelState.IsValid)
            {
                //  List<string> errorList = new List<string>();
               string errors =string.Join("\n",
                   ModelState.Values
                            .SelectMany(value => value.Errors)
                            .Select(err => err.ErrorMessage));
                //foreach(var value in ModelState.Values)
                //{
                //    foreach (var error in value.Errors)
                //    {
                //        errorList.Add(error.ErrorMessage);
                //    }
                //}
               // string errors=string.Join("\n",errorList);
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
