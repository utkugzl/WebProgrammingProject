using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProje.Models;

namespace WebProgramlamaProje.Controllers
{
    public class LoginController : Controller
    {
        private Context context = new Context();

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string Email, string Password)
        {
            var user = context.PassengerLogins.Where(u => u.Email.Equals(Email) && u.Password.Equals(Password)).ToList();
            var admin = context.AdminLogins.Where(a=> a.AdminEmail.Equals(Email) && a.AdminPassword.Equals(Password)).ToList();

            if(admin.Count > 0)
            {
                foreach (var item in admin)
                {
                    HttpContext.Session.SetString("AdminId", item.AdminID.ToString());
                    HttpContext.Session.SetString("AdminName", item.AdminName.ToString());
                    HttpContext.Session.SetString("AdminMail", item.AdminEmail.ToString());
                }
                return RedirectToAction("Dashboard","Admin");
              
            }
            if (user.Count > 0)
            {
                foreach (var item in user)
                {
                    HttpContext.Session.SetString("UserId", item.PassengerID.ToString());
                    HttpContext.Session.SetString("UserName", item.Email.ToString());
                }
                return RedirectToAction("Index", "Home");

            }
            else
            {

                ViewBag.msg = "Geçersiz email ya da şifre !!";
                return View();
            }

        }

        public IActionResult ALogout() 
        { 
            if(HttpContext.Session.GetString("AdminId") is null)
            {
                return RedirectToAction("Login","Login");
            }
            else
            {
                HttpContext.Session.Remove("AdminId");
                HttpContext.Session.Remove("AdminName");
                HttpContext.Session.Remove("AdminMail");
                return RedirectToAction("Login", "Login");
            }
            
        }

        public IActionResult PLogout()
        {
            if (HttpContext.Session.GetString("UserId") is null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                HttpContext.Session.Remove("UserId");
                HttpContext.Session.Remove("UserName");
                return RedirectToAction("Login", "Login");
            }

        }

    }
}
