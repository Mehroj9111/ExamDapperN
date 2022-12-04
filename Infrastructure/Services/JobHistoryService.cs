using Infrastructure.Context;
namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Domain.Wrapper;
public class JobHistoryService
{
    private readonly DapperContext _context;
    public JobHistoryService(DapperContext context)
    {
        _context = context;
    }
    public  async Task<Response<List<GetFullInformationDto>>> GetJobHistory()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"SELECT employee_id as EmployeeId, start_date as StartDate, end_date as EndDate, job_id as JobId, department_id as DeparmentId from JOB_HISTORY as JobHistory ";
            var result = await conn.QueryAsync<GetFullInformationDto>(sql);
            return new Response<List<GetFullInformationDto>>(result.ToList());
        }
    }
    public async Task<Response<JobHistoryDto>> InsertJobHistory(JobHistoryDto history)
    {
        try
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $"INSERT INTO JOB_HISTORY(start_date, end_date, job_id, department_id) VALUES "
                +$"({history.StartDate},{history.EndDate},{history.JobId},{history.DepartmentId})";
                var result = await conn.ExecuteAsync(sql);
                history.EmployeeId = result;
                return new Response<JobHistoryDto>(history);
            }
              }
        catch(Exception ex)
        {
            return new Response<JobHistoryDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<int> UpdatJobHistory(JobHistoryDto history)
    {
        using ( var conn = _context.CreateConnection())
        {
            var sql = $"UBDATE JOB_HISTORY SET "
            +$"start_date = {history.StartDate}, "
            +$"end_date = {history.EndDate}, "
            +$"job_id = {history.JobId}, "
            +$"department_id = {history.DepartmentId}"; 
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
    public async Task<int> DeletJobHistory(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"DELETE FROM JOB_HISTORY WHERE employee_id = {id}";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
}