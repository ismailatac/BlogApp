using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
	[AllowAnonymous]
	public class WriterController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
        public IActionResult Test()
        {
            return View();
        }

    }
}
