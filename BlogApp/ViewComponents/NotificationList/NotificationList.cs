using Business.Concretes;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents.NotificationList
{
    public class NotificationList : ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IViewComponentResult Invoke()
        {

            return View();
        }

    }
}
    
