using Microsoft.AspNetCore.Http;

namespace Domain.Dtos;
public class JobHistoryDto
{
  public int EmployeeId { get; set; }   
  public DateTime StartDate { get; set; }   
  public DateTime EndDate { get; set; }   
  public int JobId { get; set; }   
  public int DepartmentId { get; set; }   
 public IFormFile? File { get; set; }
}