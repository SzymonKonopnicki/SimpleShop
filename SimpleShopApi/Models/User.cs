using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleShopApi.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    [Required]
    [EmailAddress]
    public string Mail { get; set; }

    [Required]
    public string Password { get; set; }

    [ForeignKey("UserRole")]
    public int UserRoleId { get; set; } = 1;

    public virtual UsersRole UserRole { get; set; } = null!;
}
