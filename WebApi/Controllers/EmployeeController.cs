using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;
namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeeController
{
    private EmployeeService _employeeService;
    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("[GetEmployees]")]
    public async Task<Response<List<GetFullInformationDto>>> GetEmployees()
    {
        return await _employeeService.GetEmployees();
    }

    [HttpPost("[InsertEmployee]")]
    public async Task<Response<EmployeeDto>> InsertEmployee(EmployeeDto employees)
    {
        return await _employeeService.InsertEmployee(employees);
    }

    [HttpPut("[UbdatEmployee]")]
    public async Task<int> UpdatEmployee(EmployeeDto employees)
    {
        return await _employeeService.UpdatEmployees(employees);
    }
    
    [HttpDelete("[DeletEmployee]")]
    public async Task<int> DeleteEmployee(int id)
    {
        return await _employeeService.DeletEmployees(id);
    }
}
