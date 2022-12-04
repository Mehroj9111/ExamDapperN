using Infrastructure.Context;
namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Domain.Wrapper;

public class LocationService
{
    private readonly DapperContext _context;
    public LocationService(DapperContext context)
    {
        _context = context;
    }
    public  async Task<Response<List<GetFullInformationDto>>> GetLocations()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"SELECT location_id as LocationId,street_address as StreetAddress, postal_code as PostalCode, city, state_province as StateProvince, country_id as CountryId FROM LOCATIONS";
            var result = await conn.QueryAsync<GetFullInformationDto>(sql);
            return new Response<List<GetFullInformationDto>>(result.ToList());
        }
    }
    public async Task<Response<LocationDto>> InsertLocation(LocationDto location)
    {
        try
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $"insert into locations(street_address, postal_code, city, state_province, country_id) VALUES "
                +$"('{location.StreetAddress}',{location.PostalCode}, '{location.City}','{location.StateProvince}', {location.CountryId},";
                var result = await conn.ExecuteAsync(sql);
                location.LocationId = result;
                return new Response<LocationDto>(location);
            }
        }
        catch(Exception ex)
        {
            return new Response<LocationDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<int> UpdatLocation(LocationDto location)
    {
        using ( var conn = _context.CreateConnection())
        {
            var sql = $"UBDATE LOCATIONS SET "
            +$"street_address = '{location.StreetAddress}', "
            +$"postal_code = {location.PostalCode}, "
            +$"city = '{location.City}', "
            +$"state_province = '{location.StateProvince}', "
            +$"country_id = {location.CountryId},"; 
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
    public async Task<int> DeletLocation(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"DELETE FROM LOCATIONS WHERE location_id = {id}";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
}