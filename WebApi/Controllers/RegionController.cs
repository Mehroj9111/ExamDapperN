using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;
namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]

public class RegionController
{
    private RegionService _regionService;
    public RegionController(RegionService regionService)
    {
        _regionService = regionService;
    }

    [HttpGet("[GetRegions]")]
    public async Task<Response<List<GetFullInformationDto>>> GetRegions()
    {
        return await _regionService.GetRegions();
    }

    [HttpPost("[InsertRegions]")]
    public async Task<Response<RegionDto>> InsertRegion(RegionDto regions)
    {
        return await _regionService.InsertRegions(regions);
    }

    [HttpPut("[UbdatRegions]")]
    public async Task<int> UpdatRegion(RegionDto regions)
    {
        return await _regionService.UpdatRegions(regions);
    }
    
    [HttpDelete("[DeletRegions]")]
    public async Task<int> DeletRegion(int id)
    {
        return await _regionService.DeletRegions(id);
    }
}