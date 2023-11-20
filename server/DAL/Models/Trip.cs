using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Trip
{
    public int TripId { get; set; }

    public string? TripDestination { get; set; }

    public int? KindId { get; set; }

    public DateTime? TripDate { get; set; }

    public TimeSpan? TripTime { get; set; }

    public int? TripHour { get; set; }

    public int? TripAvailability { get; set; }

    public decimal? TripPrice { get; set; }

    public string? TripImage { get; set; }

    public virtual Kind? Kind { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
