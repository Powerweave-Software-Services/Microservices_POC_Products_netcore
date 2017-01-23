﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices_POC_Products_netcore.Models
{
    public class Products
    {
        [BsonId]
        public String Id { get; set; }
        //[BsonElement("ProductId")]
        public int ProductId { get; set; }
        //[BsonElement("ProductName")]
        public string ProductName { get; set; }
        //[BsonElement("Price")]
        public int Price { get; set; }
        //[BsonElement("Category")]
        public string Category { get; set; }
        //[BsonElement("ProductCode")]
        public string ProductCode { get; set; }
    }
}
