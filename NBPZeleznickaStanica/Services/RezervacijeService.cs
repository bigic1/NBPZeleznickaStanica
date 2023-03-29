using MongoDB.Driver;
using NBPZeleznickaStanica.IServices;
using NBPZeleznickaStanica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBPZeleznickaStanica.Services
{
    public class RezervacijeService : IRezervacijeService
    {
        MongoDBContext _dbContext = new MongoDBContext();

        public async Task<List<Rezervacije>> GetRezervacijeAsync()
            => await _dbContext.RezervacijeCollection.Find(_ => true).ToListAsync();

        public async Task<List<Rezervacije>> GetUserRezervacije(string userId)
            => await _dbContext.RezervacijeCollection.FindSync(q => q.User.Id == userId).ToListAsync();

        public async Task AddRezervacijeAsync(Rezervacije rezervacije) 
            => await _dbContext.RezervacijeCollection.InsertOneAsync(rezervacije);
        
        public async Task<Rezervacije> GetRezervacijeByIdAsync(string id)
            => await _dbContext.RezervacijeCollection.FindSync(p => p.Id == id).FirstOrDefaultAsync();
        public async Task UpdateRezervacijeAsync(Rezervacije rezervacije)
    => await _dbContext.RezervacijeCollection.ReplaceOneAsync(g => g.Id == rezervacije.Id, rezervacije);

        public async Task DeleteRezervacijeAsync(string id) 
            => await _dbContext.RezervacijeCollection.DeleteOneAsync(p => p.Id == id);
        
    }
}
