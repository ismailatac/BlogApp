using Business.Concretes;
using DataAccess.Contexts;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.BlogCount = c.Blogs.Count().ToString();
            ViewBag.BlogCountWriter = c.Blogs.Where(x => x.WriterId == 1).Count().ToString();
            ViewBag.CategoryCount = c.Categories.Count().ToString();
            var values = bm.GetListWithCategory();
            return View(values);
        }
    }
}
