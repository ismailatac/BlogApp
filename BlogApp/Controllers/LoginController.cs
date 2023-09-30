using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
