using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mix_coffeeshop_web.Models;

namespace mix_coffeeshop_web.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        public static IList<Product> products = new List<Product>
        {
            new Product{ Id = 1, Name = "JphonX 256", Price = 49000 },
            new Product{ Id = 2, Name = "Jphon8 128", Price = 27900 },
            new Product{ Id = 3, Name = "iTable 100", Price = 12500 },
            new Product{ Id = 4, Name = "Universe S9", Price = 35000 },
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return products.FirstOrDefault(it => it.Id == id);
        }

        [HttpPost]
        public Product CreateNewProduct([FromBody]Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return product;
        }

        [HttpPut("{id}")]
        public Product UpdateProduct(int id, [FromBody]Product product)
        {
            var selectedProduct = products.FirstOrDefault(it => it.Id == id);
            selectedProduct.Name = product.Name;
            selectedProduct.Price = product.Price;
            return selectedProduct;
        }
    }
}
