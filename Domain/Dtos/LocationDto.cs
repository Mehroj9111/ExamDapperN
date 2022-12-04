using Microsoft.AspNetCore.Http;

namespace Domain.Dtos;
public class LocationDto
{
    public int LocationId { get; set; }
    public string? StreetAddress { get; set; }
    public int PostalCode { get; set; }
    public string? City { get; set; }
    public string? StateProvince { get; set; }
    public int CountryId { get; set; }
    public IFormFile? File { get; set; }

}