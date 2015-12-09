using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMall.Model
{
    public class Product
    {
        public Product()
        {
            ProductStore = new Store();
            ProductCategory = new Category();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Catalog { get; set; }
        public string Model { get; set; }
        public string Currency { get; set; }
        public decimal Shipment { get; set; }
        public string DeliveryTime { get; set; }
        public string Manufacturer { get; set; }
        public string Warranty { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }
        public string Image { get; set; }
        public string ProductType { get; set; }
        public decimal? Tax { get; set; }

        public Store ProductStore { get; set; }
        public Category ProductCategory { get; set; }
    }
}