﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheMall.Model
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}