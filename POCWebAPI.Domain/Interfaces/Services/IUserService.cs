using POCWebAPI.Domain.Entities;

namespace POCWebAPI.Domain.Interfaces.Services
{
    public interface IUserService
    {
        public Task<User> Authenticate(string username, string password);
        public Task<User> Get(int id);
        public Task<User> Create(User newUser);
    }
}
