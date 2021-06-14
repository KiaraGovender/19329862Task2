using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ACMEINC_19329862.Models;
using Microsoft.AspNetCore.Http;
using ACMEINC_19329862.Details;

namespace ACMEINC_19329862.Controllers
{
    public class HomeController : Controller
    {
        private readonly ACMEINCContext _logger;

        public HomeController(ACMEINCContext logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> prolist = ProductDetails.productview();
            ViewData["pro"] = prolist;
            ViewBag.a = 1;

            if (HttpContext.Session.GetString("LoggedIn") != null)
            {
                // view previous orders of specific user
                string usernameFromTempData = TempData["usernameAsTempData"].ToString();
                return View(_logger.Orders.Where(c => c.User.UserName.Equals(usernameFromTempData)).ToList());
            } else
            {
                TempData["Login"] = "You need to login.";
                return RedirectToAction("Login", "Login");
            }
            

        }

        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
