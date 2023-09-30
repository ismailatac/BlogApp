using Business.Concretes;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
	public class AboutController : Controller
	{
		AboutManager abm = new AboutManager(new EfAboutRepository());
		public IActionResult Index()
		{
			var values = abm.GetListAll();
			return View(values);
		}
		public PartialViewResult SocialMediaAbout()
		{
			return PartialView();
		}
	}
}
