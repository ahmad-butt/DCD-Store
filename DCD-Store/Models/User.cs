using System;
using System.Collections.Generic;

namespace DCD_Store.Models;

public partial class User
{
    public long? Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? Age { get; set; }

    public string? Phone { get; set; }
}
