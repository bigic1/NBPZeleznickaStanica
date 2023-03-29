using NBPZeleznickaStanica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBPZeleznickaStanica.IServices
{
    public interface IRezervacijeService
    {

        public Task<List<Rezervacije>> GetRezervacijeAsync();
        public Task<List<Rezervacije>> GetUserRezervacije(string userId);
        public Task AddRezervacijeAsync(Rezervacije rezervacije);
        public Task<Rezervacije> GetRezervacijeByIdAsync(string id);
        public Task UpdateRezervacijeAsync(Rezervacije rezervacije);
        public Task DeleteRezervacijeAsync(string id);
    }
}
