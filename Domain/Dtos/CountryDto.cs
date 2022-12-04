using Microsoft.AspNetCore.Http;

namespace Domain.Dtos;
public class CountryDto
{
    public int CountryId { get; set; }
    public string? CountryName { get; set; }
    public int RegionId { get; set; }
     public IFormFile? File { get; set; }
}