using BlogApp.Controllers;
using BlogApp.Models;
using Business.Concretes;
using DataAccess.EntityFramework;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents.Comment
{
    public class CommentAdd : ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.id = id;
            return View();
        }

    }
}
