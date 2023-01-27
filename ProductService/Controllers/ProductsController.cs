using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductsDB products;

        public ProductsController()
        {
            products = new ProductsDB();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(products.Where(p=>p.ProductId ==id).FirstOrDefault());
        }
        [HttpPost]
        public IActionResult Post(Product product)
        {
            products.Add(product);
            return Ok(products);
        }
    }
}
