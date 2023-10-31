using Business.Concretes;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Areas.Admin.ViewComponents
{
    public class Statistic3 :ViewComponent
    {
        AdminManager adm = new AdminManager(new EfAdminRepository());
        public IViewComponentResult Invoke()
        {
            ViewBag.adminName = adm.GetById(2).Name;
            ViewBag.adminImageURL = adm.GetById(2).ImageURL;
            ViewBag.adminShortDescription = adm.GetById(2).ShortDescription;


            return View();
        }
    }
}
