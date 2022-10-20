using Dapper;
using Microsoft.Extensions.Configuration;
using POCWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using POCWebAPI.Domain.Interfaces.Repositories;

namespace POCWebAPI.Infrastructure.Repositories
{
    public class UserRepository : DbContext, IUserRepository
    {
        public async Task<User?> Authenticate(string username, string password)
        {
            using (var db = new POC_DATABASEContext())
            {
                User? user = await db.Users
                    .Where(user => user.Email == username && user.Password == password)
                    .FirstOrDefaultAsync();

                if (user != null) return user;
                return null;
            }
        }

        public async Task<User> Create(User newUser)
        {
            using (var db = new POC_DATABASEContext())
            {
                var user = await db.Users.AddAsync(newUser);
                db.SaveChanges();

                return user.Entity;
            }
        }

        public async Task<User> Select(int userId)
        {
            using (var db = new POC_DATABASEContext())
            {
                User? user = await db.Users
                    .SingleOrDefaultAsync(user => user.Id == userId);

                return user;
            }
        }
    }
}
