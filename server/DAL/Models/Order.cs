using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public TimeSpan? OrderTime { get; set; }

    public int? TripId { get; set; }

    public int? OrderPlaces { get; set; }

    public virtual Trip? Trip { get; set; }

    public virtual User? User { get; set; }
}
