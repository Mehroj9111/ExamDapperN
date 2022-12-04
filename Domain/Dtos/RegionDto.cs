using Microsoft.AspNetCore.Http;

namespace Domain.Dtos;
public class RegionDto
{
    public int RegionId { get; set; }
    public string? RegionName { get; set; }
     public IFormFile? File { get; set; }
}