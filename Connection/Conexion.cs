using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using scrap.Model;


namespace scrap.Connection
{
    internal class Conexion<T> where T : IModelo
    {
        private readonly IMongoCollection<T> _collection;
        const string connectionUri = "";
        public Conexion()
        {
            var mongoClient = new MongoClient(connectionUri);
            var dbContextOptions =
                new DbContextOptionsBuilder<MyDbContext>().UseMongoDB(mongoClient, "<HAYP>");
            var db = new MyDbContext(dbContextOptions.Options);
            var database = mongoClient.GetDatabase("HAYP");
            _collection = database.GetCollection<T>(typeof(T).Name);
        }
        public void InsertData(T componente)
        {
            _collection.InsertOne(componente);
        }
    }
}
