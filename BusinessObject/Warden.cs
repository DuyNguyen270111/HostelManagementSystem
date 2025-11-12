using System;
using System.Collections.Generic;

namespace HostelManagement.BusinessObject;

public partial class Warden
{
    public int WardenId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? HostelId { get; set; }

    public virtual Hostel? Hostel { get; set; }
}
