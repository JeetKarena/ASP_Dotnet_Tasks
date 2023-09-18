using System.ComponentModel.DataAnnotations;

namespace crud_demo.Areas.CIty.Models;

public class City
{
    [Required]
    public int? CityID { get; set; }
    [Required]
    public int? StateID { get; set; }
    [Required]
    public int? CountryID { get; set; }
    [Required]
    public string? CityName { get; set; }
    [Required]
    public string? StateName { get; set; }
    [Required]
    public string? CountryName { get; set; }
    [Required]
    public string? CityCode { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}