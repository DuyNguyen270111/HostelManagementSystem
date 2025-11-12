using System;
using System.Collections.Generic;

namespace HostelManagement.BusinessObject;

public partial class Allotment
{
    public int AllotmentId { get; set; }

    public int? StudentId { get; set; }

    public int? RoomId { get; set; }

    public DateOnly? AllotDate { get; set; }

    public DateOnly? LeaveDate { get; set; }

    public virtual Room? Room { get; set; }

    public virtual Student? Student { get; set; }
}
