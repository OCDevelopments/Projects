using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMall.Model
{
    public class Store
    {
        public Store()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}