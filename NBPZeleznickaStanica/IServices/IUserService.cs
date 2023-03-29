using NBPZeleznickaStanica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBPZeleznickaStanica.IServices
{
    public interface IUserService
    {
        public Task<List<User>> GetUsersAsync();
        public Task AddUserAsync(User user);
        public Task<User> GetUserByIdAsync(string id);
        public Task<User> GetUserAsync(string username, string password);
        public Task UpdateUserAsync(User user);
        public Task DeleteUserAsync(string id);
    }
}
