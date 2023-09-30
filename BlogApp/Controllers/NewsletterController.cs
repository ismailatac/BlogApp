using BlogApp.Models;
using Business.Concretes;
using DataAccess.EntityFramework;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class NewsletterController : Controller
    {
        NewsletterManager nm = new NewsletterManager(new EfNewsletterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsletterModel newsletterModel)
        {
            newsletterModel.MailStatus = true;
            Newsletter newsletter = new Newsletter();
            newsletter.Mail = newsletterModel.Mail;
            newsletter.MailStatus = newsletterModel.MailStatus;
            nm.Add(newsletter);
            return RedirectToAction("BlogReadAll", "Blog", new { id = $"{newsletterModel.BlogId}" });
        }
    }
}
