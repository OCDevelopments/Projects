using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheMall.API;
using TheMall.Model;
using TheMall.Repository;

namespace TheMall.API.Controllers
{
    //[Authorize]
    [RoutePrefix("api")]
    public class ProductController : ApiController
    {
//        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _uow;

        public ProductController() { }

        public ProductController(IUnitOfWork uow,IProductRepository repository)
        {
            //_repository = repository;
            _uow = uow;
        }

        //Get api/Product
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            //return _repository.GetAll();
            return _uow.Repository<Product>().GetAll();
        }

        //Get api/Product/{id}
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            //var product = _repository.Product.FirstOrDefault(o => o.Id == id);
            //var product = _repository.GetById(id);
//            var product = _uow.<Product>().GetById(id);



            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        [Route("category/{categoryId}/products")]
        public IHttpActionResult GetProductsByCategoryId(int categoryId)
        {
            var products = _repository.GetProductsByCategoryId(categoryId);

            if (!products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }
    }
}
