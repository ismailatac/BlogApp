using Business.Concretes;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IActionResult Inbox()
        {
            int id = 1;
            var values = mm.GetInboxListByWriterId(id);
            return View(values);
        }
        public IActionResult MessageContent(int id)
        {
            
            var value = mm.GetByIdWithSender(id);
            return View(value);
        }
    }
}
