using Business.Concretes;
using DataAccess.Contexts;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents.Writer
{
    public class WriterAboutDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            var context = new Context();
            var username = User.Identity.Name;
            var writerId = context.Writers.Where(x => x.Name == username).Select(y => y.WriterId).FirstOrDefault();
            var values = wm.GetById(writerId);
            return View(values);
        }
    }
}
