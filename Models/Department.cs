using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models;

public class Department
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int DivisionId { get; set; }

    //Relations
    [JsonIgnore]
    [ForeignKey("DivisionId")]
    public Division? Division { get; set; }

    [JsonIgnore]
    public ICollection<Employee>? Employees { get; set; }

}
