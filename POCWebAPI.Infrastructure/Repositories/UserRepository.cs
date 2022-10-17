using Dapper;
using Microsoft.Extensions.Configuration;
using POCWebAPI.Domain.Interfaces;
using POCWebAPI.Domain.Entities;

namespace POCWebAPI.Infrastructure.Repositories
{
    public class UserRepository : SqlServerRepository, IUserRepository
    {

        public UserRepository(IConfiguration config) : base(config)
        {
        }

        #region 'Get User'

        public User Create(User newUser)
        {
            using (var db = new POC_DATABASEContext())
            {
                var user = db.Users.Add(newUser);
                db.SaveChanges();

                return user.Entity;
            }
        }

        public User Select(int userId)
        {
            using (var db = new POC_DATABASEContext())
            {
                User user = db.Users.SingleOrDefault(user => user.Id == userId);

                return user;
            }
        }

        public User Delete(int userId)
        {
            using (var db = new POC_DATABASEContext())
            {
                User user = db.Users
                    .SingleOrDefault(user => user.Id == userId);

                db.Remove(user);
                db.SaveChanges();

                return new User();
            }
        }

        #endregion

    }
}
