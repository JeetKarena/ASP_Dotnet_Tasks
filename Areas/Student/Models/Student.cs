namespace crud_demo.Areas.Student.Models;

public class Student
{
    public int StudentID;
    public int StudentId { get; set; }
    public int BranchId { get; set; }
    public int CityId { get; set; }
    public int StateId { get; set; }
    public int CountryId { get; set; }
    public string? StudentName { get; set; }
    public string? MobileNoStudent { get; set; }
    public string? Email { get; set; }
    public string? MobileNoFather { get; set; }
    public string? Address { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}