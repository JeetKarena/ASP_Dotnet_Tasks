using System.ComponentModel.DataAnnotations;

namespace crud_demo.Areas.Branch.Models;

public class BranchDropdownModel
{
    [Required]
    public int BranchID { get; set; }
    [Required]
    public string? BranchName { get; set; }
}