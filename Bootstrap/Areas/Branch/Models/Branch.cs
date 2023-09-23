using System.ComponentModel.DataAnnotations;

namespace crud_demo.Areas.Branch.Models;

public class Branch
{
    public int BranchId { get; set; }
    [Required] public string? BranchName { get; set; }

    [Required] public string? BranchCode { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}