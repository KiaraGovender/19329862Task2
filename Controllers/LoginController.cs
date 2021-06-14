using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ACMEINC_19329862.Models;
using Microsoft.AspNetCore.Http;

namespace ACMEINC_19329862.Controllers
{
    // User Login
    public class LoginController : Controller
    {
        ACMEINCContext db = new ACMEINCContext();
        public LoginController(ACMEINCContext context)
        {
            db = context;
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            User u = db.Users.Where(us => us.UserName.Equals(Username) && us.UserPassword.Equals(Password)).FirstOrDefault();
            if (u != null)
            {
                if (u.Employee == true)
                {
                    HttpContext.Session.SetString("Admin", u.UserName);
                    TempData["usernameAsTempData"] = u.UserName;
                    return RedirectToAction("Admin", "Admin");
                }
                else
                {
                    HttpContext.Session.SetString("LoggedIn", u.UserName);
                    TempData["usernameAsTempData"] = u.UserName;
                    return RedirectToAction("IndexLogin", "Home");
                }
            } else
            {
                ViewBag.Error = "Incorrect Login Details";
                return View();
            }
        }

        public IActionResult Logout()
        {
            // clear session
            HttpContext.Session.Clear();
            return View();
        }
    }
}