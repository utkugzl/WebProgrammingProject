using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context();


        
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (HttpContext.Session.GetString("AdminId") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (HttpContext.Session.GetString("AdminId") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View();
            }
            
            
        }
    }
}
