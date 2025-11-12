using System;
using System.Collections.Generic;

namespace HostelManagement.BusinessObject;

public partial class Visitor
{
    public int VisitorId { get; set; }

    public int? StudentId { get; set; }

    public string? Name { get; set; }

    public string? Relation { get; set; }

    public DateOnly? VisitDate { get; set; }

    public TimeOnly? InTime { get; set; }

    public TimeOnly? OutTime { get; set; }

    public virtual Student? Student { get; set; }
}
