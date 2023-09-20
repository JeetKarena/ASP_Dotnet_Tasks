using System.ComponentModel.DataAnnotations;

namespace crud_demo.Areas.Student.Models;

public class Student
{
    public int StudentId { get; set; }
    [Required] public int BranchId { get; set; }
    [Required(ErrorMessage = "The City Name field is required.")] public int CityId { get; set; }
    [Required(ErrorMessage = "The State Name field is required.")] public int StateId { get; set; }
    [Required(ErrorMessage = "The Country Name field is required.")] public int CountryId { get; set; }
    [Required] public string? StudentName { get; set; }
    [Required][Phone] public string? MobileNoStudent { get; set; }
    [Required] public string? Email { get; set; }
    [Required][Phone] public string? MobileNoFather { get; set; }
    [Required] public string? Address { get; set; }
    [Required] public DateTime BirthDate { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}