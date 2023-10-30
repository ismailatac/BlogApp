using Business.Concretes;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Areas.Admin.ViewComponents
{
    public class Statistic3 :ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        ContactManager cm = new ContactManager(new EfContactRepository());
        CommentManager com = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke()
        {
            ViewBag.countBlog = bm.GetListAll().Count();
            ViewBag.countContact = cm.GetListAll().Count();
            ViewBag.countComment = com.GetListAll().Count();
            
            return View();
        }
    }
}
