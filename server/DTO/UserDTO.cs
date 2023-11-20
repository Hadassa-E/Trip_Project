using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string? UserFirstName { get; set; }

        public string? UserLastName { get; set; }

        public string? UserPhon { get; set; }

        public string? UserMail { get; set; }

        public string? UserPassword { get; set; }

        public bool? UserFirstAid { get; set; }

    }
}