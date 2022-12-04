using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Dapper;
public class CountryService
{
    private readonly DapperContext _context;
    public CountryService(DapperContext context)
    {
        _context = context;
    }
    public  async Task<Response<List<GetFullInformationDto>>> GetCountries()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"SELECT country_id as CountryId, country_name as CountryName, region_id as RegionId FROM COUNTRIES";
            var result = await conn.QueryAsync<GetFullInformationDto>(sql);
            return new Response<List<GetFullInformationDto>>(result.ToList());
        }
    }
    public async Task<Response<CountryDto>> InsertCountry(CountryDto country)
    {
        try
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $"INSERT INTO COUNTRIES(country_name ,region_id) VALUES "
                +$"('{country.CountryName}',{country.RegionId})";
                var result = await conn.ExecuteAsync(sql);
                country.CountryId = result;
                return new Response<CountryDto>(country);
            }
              }
        catch(Exception ex)
        {
            return new Response<CountryDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<int> UpdatCountry(CountryDto country)
    {
        using ( var conn = _context.CreateConnection())
        {
            var sql = $"UPDATE COUNTRIES SET"+
            $" country_name = '{country.CountryName}',"
            +$" region_id = {country.RegionId}";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
    public async Task<int> DeletCountry(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"DELETE FROM COUNTRIES WHERE country_id = {id}";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
}