using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;
namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class DepartmentController
{
    private DepartmentService _departmentService;
    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet("[GetDepartment]")]
    public async Task<Response<List<GetFullInformationDto>>> GetDepartment()
    {
        return await _departmentService.GetDepartment();
    }

    [HttpPost("[InsertS|Department]")]
    public async Task<Response<DepartmentDto>> InsertDepartment(DepartmentDto departments)
    {
        return await _departmentService.InsertDepartment(departments);
    }

    [HttpPut("[UbdatDepartment]")]
    public async Task<int> UpdatDepartment(DepartmentDto departments)
    {
        return await _departmentService.UpdatDepartment(departments);
    }
    
    [HttpDelete("[DeletDepartment]")]
    public async Task<int> DeletDepartment(int id)
    {
        return await _departmentService.DeletDepartment(id);
    }
}