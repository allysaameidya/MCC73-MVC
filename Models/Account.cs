using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MCC73MVC.Models;

public class Account
{
    [Key]
    public string NIK { get; set; }

    [Required]
    public string Password { get; set; }

    //Relations
    [JsonIgnore]
    public Employee? Employee { get; set; }

    [JsonIgnore]
    public ICollection<AccountRole>? AccountRoles { get; set; }
}
