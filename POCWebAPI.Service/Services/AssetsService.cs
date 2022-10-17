using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using POCWebAPI.Domain.Interfaces;
using POCWebAPI.Domain.Entities;

namespace POCWebAPI.Service.Services
{
    
    public class AssetsService : IAssetsService
    {
        private readonly IAssetsRepository assetsRepository;

        public AssetsService(IAssetsRepository AssetsRepository)
        {
            assetsRepository = AssetsRepository;
        }

        public List<AvailableAsset> GetAvailableAssets()
        {
            return assetsRepository.SelectAvailableAssets();
        }
        public AvailableAsset RegisterCustomAsset(AvailableAsset newAsset)
        {
            return assetsRepository.CreateCustomAsset(newAsset);
        }
    }
}
