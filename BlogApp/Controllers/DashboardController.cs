﻿using Business.Concretes;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var values = bm.GetListWithCategory();
            return View(values);
        }
    }
}