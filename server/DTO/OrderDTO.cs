using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public int? UserId { get; set; }

        public DateTime? OrderDate { get; set; }

        public TimeSpan? OrderTime { get; set; }

        public int? TripId { get; set; }

        public int? OrderPlaces { get; set; }
        public string? UserFullName { get; set; }
        public string? UserPhone { get; set; }
        public string? TripDestination { get; set; }
        public DateTime? TripDate { get; set; }
    }
}
