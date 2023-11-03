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
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.BlogCountWriter = c.Blogs.Where(x => x.WriterId == writerId).Count().ToString();
            ViewBag.CategoryCount = c.Categories.Count().ToString();
            var values = bm.GetListWithCategory();
            return View(values);
        }
    }
}
