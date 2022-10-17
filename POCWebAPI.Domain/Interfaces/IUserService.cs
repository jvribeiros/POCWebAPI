using POCWebAPI.Domain.Entities;

namespace POCWebAPI.Domain.Interfaces
{
    public interface IUserService
    {
        public User Get(int id);
        public User Create(User newUser);
        public User Delete(int id);
    }
}
