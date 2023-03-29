using MongoDB.Driver;
using NBPZeleznickaStanica.IServices;
using NBPZeleznickaStanica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBPZeleznickaStanica.Services
{
    public class PolasciService : IPolasciService
    {
        MongoDBContext _dbContext = new MongoDBContext();

        public async Task<List<Polasci>> GetPolasciAsync()
            => await _dbContext.PolasciCollection.Find(_ => true).ToListAsync();

        public async Task AddPolasciAsync(Polasci polasci)
            => await _dbContext.PolasciCollection.InsertOneAsync(polasci);

        public async Task<Polasci> GetPolasciByIdAsync(string id)
            => await _dbContext.PolasciCollection.FindSync(p => p.Id == id).FirstOrDefaultAsync();

        public async Task UpdatePolasciAsync(Polasci polasci)
            => await _dbContext.PolasciCollection.ReplaceOneAsync(g => g.Id == polasci.Id, polasci);

        public async Task DeletePolasciAsync(string id)
            => await _dbContext.PolasciCollection.DeleteOneAsync(p => p.Id == id);

    }
}