using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
	public class WriterController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
	}
}
