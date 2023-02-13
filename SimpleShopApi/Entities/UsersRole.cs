namespace SimpleShopApi.Entities;

public class UserRole
{
    [Key]
    public int UserRoleId { get; set; }

    [Required]
    public string UserRoleName { get; set; }
}
