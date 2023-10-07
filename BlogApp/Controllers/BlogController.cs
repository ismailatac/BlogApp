using Business.Concretes;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace BlogApp.Controllers
{
	[AllowAnonymous]
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
        public IActionResult GetBlogsByWriterId(int id)
        {
            var values = blogService.GetListWithCategoryByWriterId(1);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> CategoryValues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = CategoryValues; 
            return View();



        }
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult validationResult = blogValidator.Validate(blog);
            if (validationResult.IsValid)
            {
                blog.Status = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;
                blogService.Add(blog);
                return RedirectToAction("GetBlogsByWriterId", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        //[HttpDelete]
        public IActionResult BlogDelete(int id)
        {
            var blogValue = blogService.GetById(id);
            blogService.Delete(blogValue);
            return RedirectToAction("GetBlogsByWriterId", "Blog");
        }
    }
}
