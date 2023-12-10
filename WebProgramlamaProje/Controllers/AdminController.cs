using Microsoft.AspNetCore.Mvc;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    public class AdminController : Controller
    {
        Context context = new Context();


        Admin admin1 = new Admin()
        {
            AdminID = 1,
            AdminName = "Test",
            AdminPassword = "password",
        };
        public void AdminAdd()
        {
            Admin admin1 = new Admin()
            {
                AdminID = 1,
                AdminName = "admin",
                AdminPassword = "123",
            };

            context.Add(admin1);
            context.SaveChanges();

        }
        public IActionResult Index()
        {
            
            return View();

        }

        public IActionResult AdminLogin() 
        {
            //if (Session != null) { return RedirectToAction("Dashboard"); }
            return View();
        }

      

        [HttpPost]

        public IActionResult AdminLogin(Admin admin)
        {
            var query = context.AdminLogins.Where(a => a.AdminName == admin.AdminName && a.AdminPassword == admin.AdminPassword).FirstOrDefault();
            if (query != null)
            {
               //HttpContext.Session.SetString("LoggedInAdmin", admin.AdminName);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.msj = "Hatalı giriş yaptınız";
                return View();
            }
            
        }

        public IActionResult Dashboard()
        {

            return View();
        }
    }
}
