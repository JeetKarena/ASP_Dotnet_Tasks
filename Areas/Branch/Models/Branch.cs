namespace crud_demo.Areas.Branch.Models;

public class Branch
{
    public int BranchId { get; set; }
    public string? BranchName { get; set; }
    public string? BranchCode { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}