using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using POCWebAPI.Domain.Entities;
using POCWebAPI.Domain.Interfaces.Services;
using POCWebAPI.Domain.Interfaces.Repositories;

namespace POCWebAPI.Service.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository UserRepository)
        {
            userRepository = UserRepository;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            User? registeredUser = await userRepository.Authenticate(username, password);
            if (registeredUser == null) throw new Exception("User not found!");
            return registeredUser;
        }

        public async Task<User> Get(int userId)
        {
            return await userRepository.Select(userId);
        }

        public async Task<User> Create(User newUser)
        {
            return await userRepository.Create(newUser);
        }
    }
}
