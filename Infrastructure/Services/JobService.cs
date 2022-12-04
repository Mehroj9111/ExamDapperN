using Infrastructure.Context;
namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Domain.Wrapper;
public class JobService
{
    private readonly DapperContext _context;
    public JobService(DapperContext context)
    {
        _context = context;
    }
    public  async Task<Response<List<GetFullInformationDto>>> GetJobs()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"SELECT  job_id as JobId, job_title as JobTitle, min_salary as MinSalary, max_salary as Maxsalary FROM JOBS";
            var result = await conn.QueryAsync<GetFullInformationDto>(sql);
            return new Response<List<GetFullInformationDto>>(result.ToList());
        }
    }
    public async Task<Response<JobDto>> InsertJob(JobDto job)
    {
        try
        {
            using (var conn = _context.CreateConnection())
            {
                var sql = $"INSET INTO JOBS (job_title, min_salary, max_salary) VALUES "
                +$"('{job.JobTitle}',{job.MinSalary},{job.MaxSalary},')";
                var result = await conn.ExecuteAsync(sql);
                job.JobId = result;
                return new Response<JobDto>(job);
            }
              }
        catch(Exception ex)
        {
            return new Response<JobDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<int> UpdatJob(JobDto job)
    {
        using ( var conn = _context.CreateConnection())
        {
            var sql = $"UBDATE JOBS SET "
            +$"job_title = '{job.JobTitle}', "
            +$"min_salary = {job.MinSalary}, "
            +$"max_salary = {job.MaxSalary}"; 
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
    public async Task<int> DeletJob(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"DELETE FROM JOBS WHERE job_id = {id}";
            var result = await conn.ExecuteAsync(sql);
            return result;
        }
    }
}