using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
