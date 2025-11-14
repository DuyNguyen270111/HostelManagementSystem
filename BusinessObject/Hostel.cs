using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HostelManagement.BusinessObject;

public partial class Hostel
{
    [Key]
    public int HostelId { get; set; }

    [Required(ErrorMessage = "Hostel Name is required.")]
    [StringLength(50, ErrorMessage = "Hostel Name cannot exceed 50 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Location is required.")]
    [StringLength(50, ErrorMessage = "Hostel Name cannot exceed 50 characters.")]
    public string? Location { get; set; }

    [Required(ErrorMessage = "Total Rooms is required.")]
    [Range(1, 60, ErrorMessage = "Total Rooms must be between 1 and 60.")]
    public int? TotalRooms { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    public string? Status { get; set; }

    [Required(ErrorMessage = "Type is required.")]
    public string? Type { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Warden> Wardens { get; set; } = new List<Warden>();
}
