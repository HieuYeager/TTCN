using System.ComponentModel.DataAnnotations;

public class Account
{
    public int AccountID { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    [StringLength(255)]
    public string PasswordHash { get; set; }

    [Required]
    [StringLength(20)]
    public string Role { get; set; } = "Customer";

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = "Active";
}
