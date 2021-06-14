using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ACMEINC_19329862.Models;
using Microsoft.Data.SqlClient;

namespace ACMEINC_19329862.Controllers
{
    // Search for products from the database
    public class SearchController : Controller
    {
        public ActionResult Search(string search)

        {
            if (search == "")
            {
                ViewBag.a = "Please enter a search item in the search box..";
            }
            List<Product> pro = new List<Product>();
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-GCHN6G4A\SQLEXPRESS;Initial Catalog=ACMEINC;Integrated Security=True"))
            {
                conn.Open();
                string sql = @"select * from Product where pro_desc like '%" + search + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product()
                    {
                        ProductId = (int)reader["pro_id"],
                        ProductName = (string)reader["pro_name"],
                        ProductCategory = (string)reader["pro_cat"],
                        ProductPrice = (int)reader["pro_price"],
                        ProductImage= (string)reader["pro_image"]

                    };
                    pro.Add(p);
                }
                return View();
            }
    }
}