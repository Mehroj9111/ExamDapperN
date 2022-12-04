using Microsoft.AspNetCore.Http;

namespace Domain.Dtos;
public class EmployeeDto
{
    public int EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public int PhoneNumber { get; set; }
    public int DepartId { get; set; }
    public int ManagerId { get; set; }
    public int Commission { get; set; }
    public int Salary { get; set; }
    public int JobId { get; set; }
     public IFormFile? File { get; set; }
     public List<string>? FileName { get; set; }
    public DateTime HireDate { get; set; }
}
 public int EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public int PhoneNumber { get; set; }
    public int DepartId { get; set; }
    public int ManagerId { get; set; }
    public int Commission { get; set; }
    public int Salary { get; set; }
    public int JobId { get; set; }
     public List<string> File { get; set; }
    public DateTime HireDate { get; set; }
    public GetEmployeeDto()
    {
        File = new List<string>();
    }
}
