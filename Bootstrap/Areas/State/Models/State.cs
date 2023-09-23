using System.ComponentModel.DataAnnotations;

namespace crud_demo.Areas.State.Models;

public class State
{
    // This attribute specifies that this property is the primary key of the table
    public int StateID { get; set; }

    // This attribute specifies the name of the column in the table that corresponds to this property
    [Required]
    public string? StateName { get; set; }

    [Required]
    public string? StateCode { get; set; }

    // This attribute specifies that this property is a foreign key that references the CountryID column of the LOC_Country table
    [Required(ErrorMessage = "The Country Name field is required.")]
    public int? CountryID { get; set; }

    // This property represents the navigation property to the related Country entity
    public string? CountryName { get; set; }

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }
}