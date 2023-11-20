using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserFirstName { get; set; }

    public string? UserLastName { get; set; }

    public string? UserPhon { get; set; }

    public string? UserMail { get; set; }

    public string? UserPassword { get; set; }

    public bool? UserFirstAid { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
