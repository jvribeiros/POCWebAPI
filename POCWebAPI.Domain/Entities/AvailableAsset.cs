using System;
using System.Collections.Generic;

namespace POCWebAPI.Domain.Entities
{
    public partial class AvailableAsset
    {
        public AvailableAsset()
        {
            UsersAssets = new HashSet<UsersAsset>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public double CurrentPrice { get; set; }

        public virtual ICollection<UsersAsset> UsersAssets { get; set; }
    }
}
