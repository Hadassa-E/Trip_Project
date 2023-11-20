using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Kind
{
    public int KindId { get; set; }

    public string? KindName { get; set; }

    public virtual ICollection<Trip> Trips { get; } = new List<Trip>();
}
