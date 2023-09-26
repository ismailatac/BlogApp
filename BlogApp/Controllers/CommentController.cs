using Business.Concretes;
using DataAccess.EntityFramework;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
	public class CommentController : Controller
	{
		CommentManager cm = new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddComment(Comment comment)
		{
			cm.Add(comment);
			return RedirectToAction("BlogReadAll", "Blog", new { id=$"{comment.BlogId}" });
		}
		public PartialViewResult CommentListByBlog(int id)
		{
			var values = cm.GetCommentsById(id);
			return PartialView(values);
		}
	}
}
