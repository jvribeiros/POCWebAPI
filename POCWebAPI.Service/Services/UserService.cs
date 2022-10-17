using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using POCWebAPI.Domain.Interfaces;
using POCWebAPI.Domain.Entities;

namespace POCWebAPI.Service.Services
{
    
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository UserRepository)
        {
            userRepository = UserRepository;
        }

        public User Get(int userId)
        {
            return userRepository.Select(userId);
        }

        public User Create(User newUser)
        {
            return userRepository.Create(newUser);
        }

        public User Delete(int userId)
        {
            return userRepository.Delete(userId);
        }
    }
}
