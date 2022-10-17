using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POCWebAPI.Domain.Entities;
using POCWebAPI.Domain.Interfaces;
using POCWebAPI.Service.Services;

namespace POCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetsService assetsService;

        public AssetsController(IAssetsService AssetsService)
        {
            assetsService = AssetsService;
        }

        [HttpGet("GetAvailableAssets")]
        public IActionResult GetAvailableAssets()
        {
            try
            {
                List<AvailableAsset> assetsList = assetsService.GetAvailableAssets();
                return Ok(assetsList);
            }
            catch (Exception e)
            {
                return BadRequest(new HttpResponseModel()
                {
                    Message = e.Message
                });
            }
        }

        [HttpPost("CreateCustomAsset")]
        public IActionResult CreateCustomAsset([FromBody] AvailableAsset newAsset)
        {
            try
            {
                AvailableAsset newAssetCreated = assetsService.RegisterCustomAsset(newAsset);
                return Ok(newAssetCreated);
            }
            catch (Exception e)
            {
                return BadRequest(new HttpResponseModel()
                {
                    Message = e.Message
                });
            }
        }
    }
}
