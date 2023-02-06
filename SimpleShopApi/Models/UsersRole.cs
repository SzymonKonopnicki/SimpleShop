namespace SimpleShopApi.Models;

public partial class UsersRole
{
    [Key]
    public int RoleId { get; set; }

    [Required]
    public string RoleName { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
