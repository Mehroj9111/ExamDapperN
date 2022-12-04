using Microsoft.AspNetCore.Http;
namespace Domain.Dtos;
public class GetFullInformationDto
{
    public int CountryId { get; set; }
    public string? CountryName { get; set; }
    public int RegionId { get; set; }
    public int DepartmentId { get; set; }  
    public string? DepartmentName { get; set; }  
    public int ManagerId { get; set; }  
    public int LocationId { get; set; }  
    public int EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public int PhoneNumber { get; set; }
    public int DepartId { get; set; }
    public int Commission { get; set; }
    public int Salary { get; set; }
    public int JobId { get; set; }
    public IFormFile File { get; set; }
    public List<string>? FileName { get; set; }
    public DateTime HireDate { get; set; }
    public string? JobTitle { get; set; }
    public int  MinSalary { get; set; }
    public int  MaxSalary { get; set; }
    public DateTime StartDate { get; set; }   
    public DateTime EndDate { get; set; }
    public string? StateProvince { get; set; }
    public string? StreetAddress { get; set; }
    public int PostalCode { get; set; }
    public string? City { get; set; }   
    public string? RegionName { get; set; }

}