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


    }
}
