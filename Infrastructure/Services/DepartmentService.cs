using Dapper;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
namespace Infrastructure.Services;
public class DepartmentService
{
    private readonly DapperContext _context;
    public DepartmentService(DapperContext context)
    {
        _context = context;
    }
    public  async Task<Response<List<GetFullInformationDto>>> GetDepartment()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"SELECT department_id as DepartmentId, department_name as DepartmentName, manager_id as ManagerId, location_id as LocationId  FROM DEPARTMENTS";
            var result = await conn.QueryAsync<GetFullInformationDto>(sql);
            return new Response<List<GetFullInformationDto>>(result.ToList());
        }
    }
    public async Task<Response<DepartmentDto>> InsertDepartment(DepartmentDto departments)
    {
        try
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $"INSERT INTO DEPARTMENTS (department_name, manager_id , location_id ) VALUES "
                +$"('{departments.DepartmentName}' , {departments.ManagerId} , {departments.LocationId}) ";
                var result = await conn.ExecuteAsync(sql);
                departments.DepartmentId = result;
                return new Response<DepartmentDto>(departments);
            }
              }
        catch(Exception ex)
        {
            return new Response<DepartmentDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<int> UpdatDepartment(DepartmentDto departments)
    {
        using ( var conn = _context.CreateConnection())
        {
            var sql = $"UBDATE DEPARTMENTS SET "
            +$" department_name = '{departments.DepartmentName}',"
            +$" manager_id = {departments.ManagerId},"
            +$" location_id = {departments.LocationId},";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
    public async Task<int> DeletDepartment(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"DELETE FROM DEPARTMENTS WHERE department_id = {id}";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
}