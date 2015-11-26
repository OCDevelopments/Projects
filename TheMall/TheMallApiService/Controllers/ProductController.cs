using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheMallApiService.Models;

namespace TheMallApiService.Controllers
{
    //[Authorize]
    public class ProductController : ApiController
    {
        //Mock
        Product[] products = { 
            new Product { Id = 1, Name = "Chair", Category = "Groceries", Price = 1,Description  = "Include 4 legs!"}, 
            new Product { Id = 2, Name = "Table", Category = "Toys", Price = 3.75M ,Description  = "Include 3 legs!"}, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M ,Description  = "Include driller!"} 
        };

        //Get api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        //Get api/Product/{id}
        [HttpGet]
        public IHttpActionResult GetA(int id)
        {
            var product = products.FirstOrDefault(o => o.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
