using DataAccess.Contexts;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public IActionResult Index(Writer writer)
		{
			Context context = new Context();
			var dataValue = context.Writers.FirstOrDefault(x => x.Mail == writer.Mail &&
			x.Password == writer.Password);
			if (dataValue != null)
			{
				HttpContext.Session.SetString("username", writer.Mail);
				return RedirectToAction("Index", "Writer");
			}
			else
			{
				return View();
			}
			
		}
	}
}
