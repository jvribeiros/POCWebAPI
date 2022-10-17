using System;
using System.Collections.Generic;

namespace POCWebAPI.Domain.Entities
{
    public partial class UsersAsset
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long AssetId { get; set; }
        public double PaidPrice { get; set; }
        public double Quantity { get; set; }

        public virtual AvailableAsset Asset { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
