using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
namespace DTO
{
    public class TripDTO
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
        public string? KindName { get; set; }
        public bool? Paramedic
        {//true צריך פרמדיק
            get; set;
        }
    }
}
