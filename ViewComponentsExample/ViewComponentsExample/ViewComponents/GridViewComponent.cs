using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.ViewComponents
{
	public class GridViewComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(PersonGridModel grid)
		{
			//ViewData["Grid"] = personGridModel;
			return View("Default",grid);//invoked a partial view Views/Shared/Components/Grid/Default.cshtml
		}
	}
}
