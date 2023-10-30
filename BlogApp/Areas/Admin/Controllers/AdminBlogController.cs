using Business.Concretes;
using ClosedXML.Excel;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult ExportStaticExcelBlogList()
        {
            using(var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "BlogId";
                worksheet.Cell(1, 2).Value = "Title";
                worksheet.Cell(1, 3).Value = "Content";
                worksheet.Cell(1, 4).Value = "ThumbnailImage";
                worksheet.Cell(1, 5).Value = "Image";
                worksheet.Cell(1, 6).Value = "CreateDate";
                worksheet.Cell(1, 7).Value = "Status";
                worksheet.Cell(1, 8).Value = "CategoryId";
                worksheet.Cell(1, 9).Value = "WriterId";

                int blogRowCount = 2;
                foreach (var item in bm.GetListAll())
                {
                    worksheet.Cell(blogRowCount, 1).Value = item.BlogId;
                    worksheet.Cell(blogRowCount, 2).Value = item.Title;
                    worksheet.Cell(blogRowCount, 3).Value = item.Content;
                    worksheet.Cell(blogRowCount, 4).Value = item.ThumbnailImage;
                    worksheet.Cell(blogRowCount, 5).Value = item.Image;
                    worksheet.Cell(blogRowCount, 6).Value = item.CreateDate;
                    worksheet.Cell(blogRowCount, 7).Value = item.Status;
                    worksheet.Cell(blogRowCount, 8).Value = item.CategoryId;
                    worksheet.Cell(blogRowCount, 9).Value = item.WriterId;
                    blogRowCount++;
                }
                
                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "blog_listesi.xlsx");
                }
            }
            
           
        }
        public IActionResult ExcelBlogList()
        {
            return View();
        }
    }
}
