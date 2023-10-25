using BlogApp.Models;
using Business.Concretes;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var value = wm.GetById(1);
            return View(value);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult result = validator.Validate(writer);
            if (result.IsValid)
            {
                wm.Update(writer);
                return RedirectToAction("Index", "Dashboard");

            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage writer)
        {
            Writer w = new Writer();
            if (writer.Image != null)
            {
                var extension = Path.GetExtension(writer.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                writer.Image.CopyTo(stream);
                w.Image = newImageName;
            }
            w.Mail = writer.Mail;
            w.Name = writer.Name;
            w.Password = writer.Password;
            w.Status = true;
            w.About = writer.About;

            wm.Add(w);
            return RedirectToAction("Index", "Dashboard");
        }




    }
}
