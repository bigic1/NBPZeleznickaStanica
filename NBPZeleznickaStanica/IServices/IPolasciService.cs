using NBPZeleznickaStanica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBPZeleznickaStanica.IServices
{
    public interface IPolasciService
    {
        public Task<List<Polasci>> GetPolasciAsync();
        public Task AddPolasciAsync(Polasci polasci);
        public Task<Polasci> GetPolasciByIdAsync(string id);
        public Task UpdatePolasciAsync(Polasci polasci);
        public Task DeletePolasciAsync(string id);
    }
}