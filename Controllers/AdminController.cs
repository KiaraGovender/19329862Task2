using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ACMEINC_19329862.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;

namespace ACMEINC_19329862.Controllers
{
    public class AdminController : Controller
    {
        ACMEINCContext db = new ACMEINCContext();
        private readonly ACMEINCContext _logger;
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Admin") != null)
            {
                // Admin can view Order history of all users
                string usernameFromTempData = TempData["usernameAsTempData"].ToString();
                return View(_logger.Orders.ToList());
            }
            else
            {
                TempData["Login"] = "You need to login.";
                return RedirectToAction("Login", "Login");
            }
        }

        // CODE ATTRIBUTION
        // MVC - Chart - Create Simple Chart and Load Data From Database Entity Framework, by Vis Dotnet
        // YouTube Link: https://www.youtube.com/watch?v=GHLPtznTr1s
        // Blogspot Link: https://howtodomssqlcsharpexcelaccess.blogspot.com/2019/05/mvc-chart-create-simple-chart-and-load.html
        // Populate chart with data from database
        public ActionResult GetChartImage()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var results = db.Orders.ToList();
            results.ToList().ForEach(rs => xValue.Add(rs.Product.ProductCategory));
            results.ToList().ForEach(rs => yValue.Add(rs.User.UserId));
            var key = new Chart(width: 300, height: 300)
                .AddTitle("Months")
                .AddSeries(chartType: "Pie",
                name: "Some Name",
                xValue: xValue,
                yValues: yValue);
            return File(key.ToWebImage().GetBytes(), "image/jpeg");
        }

    }
}