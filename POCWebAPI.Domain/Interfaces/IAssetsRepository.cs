using POCWebAPI.Domain.Entities;


namespace POCWebAPI.Domain.Interfaces
{
    public interface IAssetsRepository
    {
        List<AvailableAsset> SelectAvailableAssets();
        AvailableAsset CreateCustomAsset(AvailableAsset newAsset);
    }
}
