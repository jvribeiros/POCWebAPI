using POCWebAPI.Domain.Entities;


namespace POCWebAPI.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> Authenticate(string username, string password);
        public Task<User> Select(int userId);
        public Task<User> Create(User newUser);
    }
}
