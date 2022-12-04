using Infrastructure.Context;
namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Domain.Wrapper;

public class RegionService
{
    private readonly DapperContext _context;
    public RegionService(DapperContext context)
    {
        _context = context;
    }
    public  async Task<Response<List<GetFullInformationDto>>> GetRegions()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"SELECT region_id as RegionId, regione_name as RegioneName FROM REGIONS";
            var result = await conn.QueryAsync<GetFullInformationDto>(sql);
            return new Response<List<GetFullInformationDto>>(result.ToList());
        }
    }
    public async Task<Response<RegionDto>> InsertRegions(RegionDto region)
    {
        try
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $"INSERT INTO REGIONS(region_name ) VALUES"
                +$"('{region.RegionName}')";
                var result = await conn.ExecuteAsync(sql);
                region.RegionId = result;
                return new Response<RegionDto>(region);
            }
        }
        catch(Exception ex)
        {
            return new Response<RegionDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<int> UpdatRegions(RegionDto region)
    {
        using ( var conn = _context.CreateConnection())
        {
            var sql = $"UBDATE REGIONS SET "
            +$"region_name = '{region.RegionName}'";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
    public async Task<int> DeletRegions(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"DELETE FROM REGIONS WHERE redion_id = {id}";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
}