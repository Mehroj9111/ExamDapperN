using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
public class EmployeeService
{
    private readonly DapperContext _context;
    private readonly IWebHostEnvironment _accept;
    public EmployeeService(DapperContext context, IWebHostEnvironment accept)
    {
        _context = context;
        _accept = accept;
    }
    public  async Task<Response<List<GetFullInformationDto>>> GetEmployees()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"SELECT employee_id as EmployeeId, first_name as FirstName, last_name as LastName, email ,phone_number as PhoneNumber, department_id as DepartmentId, manager_id as ManagerId, commission, salary, job_id as JobId, hire_date as HireDate FROM EMPLOYEES";
            var result = await conn.QueryAsync<GetFullInformationDto>(sql);
            return new Response<List<GetFullInformationDto>>(result.ToList());
        }
    }
    public async Task<Response<EmployeeDto>> InsertEmployee(EmployeeDto employee)
    {
        try
        {
            using (var con = _context.CreateConnection())
            {
                var path = Path.Combine(_accept.WebRootPath, "images", employee.File.FileName);
            
                using (var res = File.Create(path))
                {
                    await employee.File.CopyToAsync(res);
                }
                var insertedId = await con.ExecuteScalarAsync<int>($"INSERT INTO EMPLOYEES(first_name, last_name, email , phone_number, department_id , manager_id , commission , salary, job_id , hire_date ) VALUES "
                +$"('{employee.FirstName}','{employee.LastName}','{employee.Email}','{employee.PhoneNumber}', '{employee.DepartId}', '{employee.ManagerId}', '{employee.Commission}', '{employee.Salary}', '{employee.JobId}', '{employee.HireDate}')");
                employee.EmployeeId = insertedId;
                var response = new EmployeeDto()
                {
                    EmployeeId = employee.EmployeeId, FirstName = employee.FirstName, LastName = employee.LastName, Email = employee.Email, PhoneNumber = employee.PhoneNumber, DepartId = employee.DepartId,  ManagerId = employee.ManagerId, Commission = employee.Commission,  Salary = employee.Salary, JobId = employee.JobId,  HireDate = employee.HireDate,  FileName= employee.FileName
                };
                return new Response<EmployeeDto>(response);
            }
        }
        catch(Exception ex)
        {
            return new Response<EmployeeDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<int> UpdatEmployees(EmployeeDto employee)
    {
        using ( var conn = _context.CreateConnection())
        {
            var sql = $"UBDATE EMPLOYEES SET "
            +$"first_name = '{employee.FirstName}',"
            +$"last_name = '{employee.LastName}', "
            +$"email = '{employee.Email}', "
            +$"phone_number = '{employee.PhoneNumber}', "
            +$"department_id = {employee.DepartId}, "
            +$"manager_id = {employee.ManagerId}, "
            +$"commission = {employee.Commission}, "
            +$"salary = {employee.Salary}, "
            +$"job_id = {employee.JobId}, "
            +$"hire_date = {employee.HireDate},"; 
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
    public async Task<int> DeletEmployees(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"DELETE FROM EMPLOYEES WHERE employee_id = {id}";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
}