using POCWebAPI.Domain.Entities;


namespace POCWebAPI.Domain.Interfaces
{
    public interface IUserRepository
    {
        User Select(int userId);
        User Create(User newUser);
        User Delete(int userId);
    }
}
