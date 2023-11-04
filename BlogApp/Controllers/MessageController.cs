using Business.Concretes;
using DataAccess.Contexts;
using DataAccess.EntityFramework;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogApp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        Context c = new Context();
        public IActionResult Inbox()
        {
            var context = new Context();
            var username = User.Identity.Name;
            var writerId = context.Writers.Where(x => x.Name == username).Select(y => y.WriterId).FirstOrDefault();
            var values = mm.GetInboxListByWriterId(writerId);
            return View(values);
        }
        public IActionResult MessageContent(int id)
        {

            var value = mm.GetByIdWithSender(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            List<SelectListItem> Receivers = (from x in c.Writers.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.WriterId.ToString()
                                                   }).ToList();
            ViewBag.Receivers = Receivers;
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
            message.SenderId = writerId;
            message.Status = true;
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.Add(message);
            return View();
        }
        [HttpGet]
        public IActionResult Sendbox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = mm.GetSendboxListByWriterId(writerId);
            return View();
        }
    }
}

