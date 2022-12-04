using Microsoft.AspNetCore.Http;

namespace Domain.Dtos;
public class JobDto
{
    public int JobId { get; set; }
    public string? JobTitle { get; set; }
    public int  MinSalary { get; set; }
    public int  MaxSalary { get; set; }
     public IFormFile? File { get; set; }
}