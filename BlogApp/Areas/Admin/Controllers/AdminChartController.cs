using BlogApp.Areas.Admin.Models;
using Business.Concretes;
using DataAccess.Contexts;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminChartController : Controller
    {
        Context c = new Context();

        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CategoryChart()
        {
            var listCatgories = c.Categories.ToList();
            var listBlogs = c.Blogs.ToList();
            var categoryList = new List<CategoryChartModel>();

            var categoryCountList = listBlogs
            .GroupBy(blog => blog.CategoryId)
             .Select(group => new
             {
                 categoryId = group.Key,
                 categoryCount = group.Count()
             });

            foreach (var item in categoryCountList)
            {
                categoryList.Add(
                    new CategoryChartModel
                    {
                        categoryname = c.Categories.Find(item.categoryId).Name,
                        categorycount = item.categoryCount
                    });

        }



            return Json(new { jsonlist = categoryList });
    }
}
}
