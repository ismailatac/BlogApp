using BlogApp.Areas.Admin.Models;
using Business.Concretes;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var writerList = wm.GetListAll();
            var writerModelList = new List<WriterModel>();
            foreach (var item in writerList)
            {
                writerModelList.Add(new WriterModel
                {
                    WriterId = item.WriterId,
                    Name = item.Name
                });
            }

            var jsonWriters = JsonConvert.SerializeObject(writerModelList);
            return Json(jsonWriters);
        }

    }
}
