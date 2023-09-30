using Business.Concretes;
using DataAccess.EntityFramework;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
	public class ContactController : Controller
	{
		ContactManager cm = new ContactManager(new EfContactRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
			contact.Status = true;
			cm.Add(contact);
			return RedirectToAction("Index","Blog");
		}
	}
}
