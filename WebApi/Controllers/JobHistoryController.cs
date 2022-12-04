using Domain.Wrapper;
using Infrastructure.Services;
namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;

[ApiController]
[Route("[controller]")]

public class JobHistoryeController
{
    private JobHistoryService _jobhistoryService;
    public JobHistoryeController(JobHistoryService historyService)
    {
        _jobhistoryService = historyService;
    }

    [HttpGet("[GetJobHistory]")]
    public async Task<Response<List<GetFullInformationDto>>> GetJobHistorys()
    {
        return await _jobhistoryService.GetJobHistory();
    }

    [HttpPost("[InsertJobHistory]")]
    public async Task<Response<JobHistoryDto>> InsertJobHistory(JobHistoryDto histories)
    {
        return await _jobhistoryService.InsertJobHistory(histories);
    }

    [HttpPut("[UbdatJobHistory]")]
    public async Task<int> UpdateJobHistory(JobHistoryDto histories)
    {
        return await _jobhistoryService.UpdatJobHistory(histories);
    }
    
    [HttpDelete("[DeletJobHistory]")]
    public async Task<int> DeleteJobHistory(int id)
    {
        return await _jobhistoryService.DeletJobHistory(id);
    }
}