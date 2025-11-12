using System;
using System.Collections.Generic;

namespace HostelManagement.BusinessObject;

public partial class Complaint
{
    public int ComplaintId { get; set; }

    public int? StudentId { get; set; }

    public int? RoomId { get; set; }

    public string? Issue { get; set; }

    public DateOnly? DateFiled { get; set; }

    public string? Status { get; set; }

    public virtual Room? Room { get; set; }

    public virtual Student? Student { get; set; }
}
