using System;
using System.Collections.Generic;

namespace POCWebAPI.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            UsersAssets = new HashSet<UsersAsset>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<UsersAsset> UsersAssets { get; set; }
    }
}
