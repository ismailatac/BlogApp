using Business.Concretes;
using DataAccess.Contexts;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents.Writer
{
    public class WriterLastBlog : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var context = new Context();
            var usermail = User.Identity.Name;
            var writerId = context.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var values = bm.GetListByWriterId(writerId);
            return View(values);
        }
    }
}
