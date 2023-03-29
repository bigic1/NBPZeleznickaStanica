using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Linq;

namespace NBPZeleznickaStanica.Models
{
    public class Polasci
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string KreceIz { get; set; }
        public string DolaziU { get; set; }
        public string VremePolaska { get; set; }
        public string VremeDolaska { get; set; }
        public int Kapacitet { get; set; }
        public int BrojRez { get; set; }
        public int Cena { get; set; }

        
    }
}
