using System;
using System.Collections.Generic;

namespace HostelManagement.BusinessObject;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? StudentId { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? Date { get; set; }

    public string? Method { get; set; }

    public string? Status { get; set; }

    public virtual Student? Student { get; set; }
}
