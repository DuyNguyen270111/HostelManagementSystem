using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HostelManagement.BusinessObject;

public partial class Room
{
    public int RoomId { get; set; }

    [Required(ErrorMessage = "Hostel is required.")]
    public int? HostelId { get; set; }

    [Required(ErrorMessage = "Room number is required.")]
    [StringLength(10, ErrorMessage = "Room number cannot exceed 10 characters.")]
    public string? RoomNumber { get; set; }

    [Required(ErrorMessage = "Capacity is required.")]
    [Range(1, 10, ErrorMessage = "Capacity must be between 1 and 10.")]
    public int? Capacity { get; set; }

    [Required(ErrorMessage = "Occupied is required.")]
    [Range(0, 10, ErrorMessage = "Occupied must be between 0 and 10.")]
    public int? Occupied { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    public string? Status { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Allotment> Allotments { get; set; } = new List<Allotment>();

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual Hostel? Hostel { get; set; }
}
