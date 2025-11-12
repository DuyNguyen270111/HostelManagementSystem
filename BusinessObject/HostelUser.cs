using System;
using System.Collections.Generic;

namespace HostelManagement.BusinessObject;

public partial class HostelUser
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }
}
