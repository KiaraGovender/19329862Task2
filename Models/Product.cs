using System;
using System.Collections.Generic;

#nullable disable

namespace ACMEINC_19329862.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductQuantity { get; set; }
        public int? ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public string ProductImage { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
