using Dapper;
using Microsoft.Extensions.Configuration;
using POCWebAPI.Domain.Interfaces;
using POCWebAPI.Domain.Entities;
using System.Diagnostics.Contracts;

namespace POCWebAPI.Infrastructure.Repositories
{
    public class AssetsRepository : IAssetsRepository
    {
        public AvailableAsset CreateCustomAsset(AvailableAsset newAsset)
        {
            using (var db = new POC_DATABASEContext())
            {
                var newAssetCreated = db.Add(newAsset);
                db.SaveChanges();

                return newAssetCreated.Entity;
            }
        }

        public List<AvailableAsset> SelectAvailableAssets()
        {
            using (var db = new POC_DATABASEContext())
            {
                return db.AvailableAssets.ToList();
            }
        }
    }
}
