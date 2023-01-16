using System;
using System.Collections.Generic;

namespace SimpleShopApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string LastName { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? Mail { get; set; }

    public string? Password { get; set; }

    public int UserRoleId { get; set; }

    public virtual UsersRole UserRole { get; set; } = null!;
}
