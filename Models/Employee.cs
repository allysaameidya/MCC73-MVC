using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models;

public class Employee
{
    [Key]
    public string NIK { get; set; }
    [Required]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required]
    public Jk Gender { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    //Relations
    [JsonIgnore]
    [ForeignKey("DepartmentId")]
    public Department? Department { get; set; }

    [JsonIgnore]
    public Account? Account { get; set; }
}
public enum Jk
{
    Male,
    Female
}

