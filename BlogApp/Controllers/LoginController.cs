using BlogApp.Models;
using DataAccess.Contexts;
using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInModel userSignInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userSignInModel.UserName, userSignInModel.Password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            
            return View();
        }



        //[HttpPost]
        //public async Task<IActionResult> Index(Writer writer)
        //{
        //	Context context = new Context();
        //	var dataValue = context.Writers.FirstOrDefault(x => x.Mail == writer.Mail &&
        //	x.Password == writer.Password);
        //	if (dataValue != null)
        //	{
        //		var claims = new List<Claim>
        //		{
        //			new Claim(ClaimTypes.Name,writer.Mail)
        //		};
        //		var userIdentity = new ClaimsIdentity(claims, "Bearer");
        //		ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //		await HttpContext.SignInAsync(principal);
        //		return RedirectToAction("GetBlogsByWriterId", "Blog");
        //	}
        //	return RedirectToAction("Index", "Dashboard");

        //}
    }
}

// HttpContext.Session.SetString("username", writer.Mail);
