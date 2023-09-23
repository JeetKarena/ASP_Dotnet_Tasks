using System.ComponentModel.DataAnnotations;

namespace crud_demo.Models;

public class Country
{
    public int? CountryId { get; set; }
    [Required] public string? CountryName { get; set; }
    [Required] public string? CountryCode { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified { get; set; }
}