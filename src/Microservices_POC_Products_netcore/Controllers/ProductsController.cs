﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservices_POC_Products_netcore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservices_POC_Products_netcore.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController: Controller
    {
        DataAccess DBobj;

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            DBobj = new DataAccess();
            return DBobj.GetProducts();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public Products Get(int id)
        {
            DBobj = new DataAccess();
            Products product = DBobj.GetProducts(id);
            if (product == null)
            {
                return product;
            }
            return product;
        }

        // POST: api/Product
        [HttpPost]
        public string Post([FromBody]Products P)
        {
            //var jsonString= JsonConvert.DeserializeObject<Products>(P);
            //[{"Id":"5876255957a6efed87f347aa","ProductId":1,"ProductName":"Desktop All in One","Price":43000,"Category":"Electronics"},{"Id":"5876258857a6efed87f347ab","ProductId":2,"ProductName":"Computers","Price":53000,"Category":"Electronics"},{"Id":"587633a6dffba129881caaf3","ProductId":3,"ProductName":"Collar Shirts","Price":1500,"Category":"Apparels"}]
            Products product = new Products();
            product.Id = Guid.NewGuid().ToString();
            product.ProductId = P.ProductId;
            product.ProductName = P.ProductName;
            product.Category = P.Category;
            product.ProductCode = P.ProductCode;
            product.Price = P.Price;
            DBobj = new DataAccess();
            Products str = DBobj.Create(product);
            return "Product " + str.ProductName.ToString() + " successfully inserted.";
        }

        // PUT: api/Product/5
        [HttpPut]
        public string Put(int Id, [FromBody]Products P)
        {
            Products product = new Products();
            product.ProductId = P.ProductId;
            product.ProductName = P.ProductName;
            product.Category = P.Category;
            product.Price = P.Price;
            product.ProductCode = P.ProductCode;
            DBobj = new DataAccess();
            string str = DBobj.Update(Id, product);
            return "Product " + P.ProductName + " updated successfully.";
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Products product = new Products();
            product.ProductId = id;
            DBobj = new DataAccess();
            string str = DBobj.Remove(id);
            return "Product deleted successfully.";
        }
    }
}
