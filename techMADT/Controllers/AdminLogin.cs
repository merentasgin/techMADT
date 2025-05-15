using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using techMADT.Models;

namespace techMADT.Controllers
{
    public class LoginController : Controller
    {
        private readonly TechnologyWebSiteDbContext _context;

        public LoginController(TechnologyWebSiteDbContext context)
        {
            _context = context;
        }

        // GET: Login
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string usNickname, string usPassword)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.UsNickname == usNickname && u.UsPassword == usPassword);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UsId);
                HttpContext.Session.SetString("UserName", user.UsName);
                HttpContext.Session.SetInt32("UserRole", user.UsType ?? 0);

                // Örneğin admin rolü 1 ise admin dashboard'a, diğer kullanıcılar home'a
                if (user.UsType == 1)
                    return RedirectToAction("Dashboard", "Admin");
                else
                    return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
            return View();
        }

        // GET: Login/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
