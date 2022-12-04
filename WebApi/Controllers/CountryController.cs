using Domain.Wrapper;
namespace WebApi.Controllers;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;
[ApiController]
[Route("[controller]")]
public class CountryController
{
    private CountryService _countryService;
    public CountryController(CountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet("[GetCountries]")]
    public async Task<Response<List<GetFullInformationDto>>> GetCountries()
    {
        return await _countryService.GetCountries();
    }

    [HttpPost("[InsertCountry]")]
    public async Task<Response<CountryDto>> InsertCountry(CountryDto countrys)
    {
        return await _countryService.InsertCountry(countrys);
    }

    [HttpPut("[UbdatCountry]")]
    public async Task<int> UpdatCountry(CountryDto countrys)
    {
        return await _countryService.UpdatCountry(countrys);
    }
    
    [HttpDelete("[DeletCountry]")]
    public async Task<int> DeletCountry(int id)
    {
        return await _countryService.DeletCountry(id);
    }
}