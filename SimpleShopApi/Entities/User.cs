namespace SimpleShopApi.Entities;

public class User
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
    public int UserRoleId { get; set; }

    public virtual UserRole UserRole { get; set; }
}
