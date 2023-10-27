using Business.Concretes;
using DataAccess.Contexts;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [AllowAnonymous]
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllNotification()
        {
            var context = new Context();
            var usermail = User.Identity.Name;
            var writerId = context.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
            //var values = nm.GetListAllByWriterId(writerId);
            return View();
        }
    }
}
