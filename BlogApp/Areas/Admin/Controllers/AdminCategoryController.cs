using Business.Abstracts;
using Business.Concretes;
using Business.ValidationRules;
using DataAccess.Contexts;
using DataAccess.EntityFramework;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using X.PagedList;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = cm.GetListAll().ToPagedList(page,3);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {
                category.Status = true;
                cm.Add(category);

                string? host = HttpContext.Request.Host.Host;
                int? port = HttpContext.Request.Host.Port;
                return Redirect(url: Url.ActionLink("Index", "AdminCategory", host: host + ":" + port + "/Admin"));
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
        
        public IActionResult DeleteCategory(int id)
        {
            cm.Delete(cm.GetById(id));
            string? host = HttpContext.Request.Host.Host;
            int? port = HttpContext.Request.Host.Port;
            return Redirect(url: Url.ActionLink("Index", "AdminCategory", host: host + ":" + port + "/Admin"));
        }
    }

}
