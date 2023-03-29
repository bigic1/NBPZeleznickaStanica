using MongoDB.Driver;
using NBPZeleznickaStanica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBPZeleznickaStanica
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _mongoDB;

        public MongoDBContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _mongoDB = client.GetDatabase("Baza");
        }
        
        public IMongoCollection<User> UserCollection
            => _mongoDB.GetCollection<User>("User");
        
        public IMongoCollection<Polasci> PolasciCollection
            => _mongoDB.GetCollection<Polasci>("Polasci");

        public IMongoCollection<Rezervacije> RezervacijeCollection
            => _mongoDB.GetCollection<Rezervacije>("Rezervacije");
    }
}
