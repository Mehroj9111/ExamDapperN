using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class LocationController
{
    private LocationService _locationService;
    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("[GetLocations]")]
    public async Task<Response<List<GetFullInformationDto>>> GetLocations()
    {
        return await _locationService.GetLocations();
    }

    [HttpPost("[InsertLocations]")]
    public async Task<Response<LocationDto>> InsertLocation(LocationDto locations)
    {
        return await _locationService.InsertLocation(locations);
    }

    [HttpPut("[UbdateLocations]")]
    public async Task<int> UpdateLocation(LocationDto locations)
    {
        return await _locationService.UpdatLocation(locations);
    }
    
    [HttpDelete("[DeletLocations]")]
    public async Task<int> DeletLocation(int id)
    {
        return await _locationService.DeletLocation(id);
    }
}