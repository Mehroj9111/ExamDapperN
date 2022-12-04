using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class JobController
{
    private JobService _jobService;
    public JobController(JobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet("[GetJobs]")]
    public async Task<Response<List<GetFullInformationDto>>> GetJobs()
    {
        return await _jobService.GetJobs();
    }

    [HttpPost("[InsertJob]")]
    public async Task<Response<JobDto>> InsertJob(JobDto jobs)
    {
        return await _jobService.InsertJob(jobs);
    }

    [HttpPut("[UbdateJob]")]
    public async Task<int> UpdateJob(JobDto jobs)
    {
        return await _jobService.UpdatJob(jobs);
    }
    
    [HttpDelete("[DeletJob]")]
    public async Task<int> DeleteJob(int id)
    {
        return await _jobService.DeletJob(id);
    }
}
