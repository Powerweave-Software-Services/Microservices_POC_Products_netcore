using Microservices_POC_Products_netcore.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace Microservices_POC_Products_netcore
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public DataAccess()
        {
            var MongoDBHost = "mongodb://sa:sa@ds127399.mlab.com:27399/";
            var MongoDBName = "alfred_products";
            _client = new MongoClient(MongoDBHost);
            _server = _client.GetServer();
            _db = _server.GetDatabase(MongoDBName);
            //_db = _server.GetDatabase("test");
        }

        public IEnumerable<Products> GetProducts()
        {
            return _db.GetCollection<Products>("Products").FindAll();
        }


        public Products GetProducts(int id)
        {
            var res = Query<Products>.EQ(p => p.ProductId, id);
            return _db.GetCollection<Products>("Products").FindOne(res);
        }

        public Products Create(Products p)
        {
            _db.GetCollection<Products>("Products").Save(p);
            return p;
        }

        public string Update(int id, Products p)
        {
            var res = Query<Products>.EQ(pd => pd.ProductId, id);
            UpdateBuilder updateBuilder = MongoDB.Driver.Builders.Update.Set("ProductName", p.ProductName)
                .Set("ProductCode", p.ProductCode)
                .Set("Category", p.Category)
                .Set("Price", p.Price);
            var result = _db.GetCollection<Products>("Products").Update(res, updateBuilder);


            // var operation = Update<Products>.Replace(p);
            //mCollection.Update(Query.EQ(pd.ProductId, id), updateBuilder);
            // var result = _db.GetCollection<Products>("Products").Update(res, operation, WriteConcern.Acknowledged);
            //_db.GetCollection<Products>("Products").Update(res, operation);
            return result.ToString();
        }
        public string Remove(int id)
        {
            var res = Query<Products>.EQ(e => e.ProductId, id);
            var operation = _db.GetCollection<Products>("Products").Remove(res);
            return operation.ToString();
        }
    }
}
