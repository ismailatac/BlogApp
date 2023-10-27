using Business.Concretes;
using DataAccess.Contexts;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IActionResult Inbox()
        {
            var context = new Context();
            var usermail = User.Identity.Name;
            var writerId = context.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = mm.GetInboxListByWriterId(writerId);
            return View(values);
        }
        public IActionResult MessageContent(int id)
        {
            
            var value = mm.GetByIdWithSender(id);
            return View(value);
        }
    }
}
