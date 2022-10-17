using POCWebAPI.Domain.Entities;

namespace POCWebAPI.Domain.Interfaces
{
    public interface IAssetsService
    {
        public List<AvailableAsset> GetAvailableAssets();
        public AvailableAsset RegisterCustomAsset(AvailableAsset newAsset);
    }
}
