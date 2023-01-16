using System;
using System.Collections.Generic;

namespace SimpleShopApi.Models;

public partial class UsersRole
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
