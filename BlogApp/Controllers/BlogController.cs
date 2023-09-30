using Business.Abstracts;
using Business.Concretes;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogService = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = blogService.GetListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = blogService.GetBlogsById(id);
            ViewBag.WriterId = values[0].WriterId;
            return View(values);
        }
    }
}
