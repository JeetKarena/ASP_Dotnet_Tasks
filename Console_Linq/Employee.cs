using System.ComponentModel.DataAnnotations;

namespace Console_Linq;

public class Employee
{
    [Key] public int AccountNo { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNo { get; set; }
    public string? Email { get; set; }
    public decimal? Salary { get; set; }
    public DateTime? JoiningDate { get; set; }
    public int? Age { get; set; }
    public string? City { get; set; }
    public string? Department { get; set; }
    public string? Gender { get; set; }
}