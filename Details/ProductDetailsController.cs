using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ACMEINC_19329862.Models;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace ACMEINC_19329862.Details
{
    // Creating a List of the Products model
    public class ProductDetails
    {
        public static List<Product> productview()
        {
            List<Product> pro = new List<Product>();
            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-GCHN6G4A\SQLEXPRESS;Initial Catalog=ACMEINC;Integrated Security=True"))
            {
                connection.Open();
                string sql = @"SELECT * from Product";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product()
                    {
                        ProductId = (int)reader["pro_id"],
                        ProductName = (string)reader["pro_name"],
                        ProductCategory = (string)reader["pro_cat"],
                        ProductPrice = (int)reader["pro_price"],
                        ProductImage = (string)reader["pro_image"]
                    };
                    pro.Add(p);
                    Debug.WriteLine(p.ProductId);
                }
            }
            return pro;
        }
    }
}