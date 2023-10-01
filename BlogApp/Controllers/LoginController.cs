using DataAccess.Contexts;
using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
		public async Task<IActionResult> Index(Writer writer)
		{
			Context context = new Context();
			var dataValue = context.Writers.FirstOrDefault(x => x.Mail == writer.Mail &&
			x.Password == writer.Password);
			if (dataValue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,writer.Mail)
				};
				var userIdentity = new ClaimsIdentity(claims, "Bearer");
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Writer");
			}
			return RedirectToAction("Index", "Login");

		}
	}
}
//Context context = new Context();
//var dataValue = context.Writers.FirstOrDefault(x => x.Mail == writer.Mail &&
//x.Password == writer.Password);
//if (dataValue != null)
//{
//	HttpContext.Session.SetString("username", writer.Mail);
//	return RedirectToAction("Index", "Writer");
//}
//else
//{
//	return View();
//}