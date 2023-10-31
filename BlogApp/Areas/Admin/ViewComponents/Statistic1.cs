using BlogApp.Areas.Admin.Models;
using Business.Concretes;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogApp.Areas.Admin.ViewComponents
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        ContactManager cm = new ContactManager(new EfContactRepository());
        CommentManager com = new CommentManager(new EfCommentRepository());
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.countBlog = bm.GetListAll().Count();
            ViewBag.countContact = cm.GetListAll().Count();
            ViewBag.countComment = com.GetListAll().Count();

            string apiKey = "*****************************";
            string connection = "https://api.openweathermap.org";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(connection);
                HttpResponseMessage response = await client.GetAsync("/data/2.5/weather?id=323779&appid=" + apiKey);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<WeatherResponseModel>(responseBody);
                    ViewBag.cityName = responseData.name;
                    ViewBag.temp = responseData.main.temp.ToString().Substring(0, 2);
                }

            }

            //XDocument document = XDocument.Load(connection);
            //string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());

            //ViewBag.antakyaDegree = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;


            return View();
        }
    }
}
