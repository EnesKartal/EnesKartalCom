using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnesKartalCom.Data.Models
{
    public class AppUser : BaseEntity
    {
        public AppUser()
        {
            AppUserLogs = new HashSet<AppUserLog>();
        }

        public string Email { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public string Mobile { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string TcNumber { get; set; }
        public string Firstname { get; set; }
        public string LastLoginIp { get; set; }
        public DateTime LastLoginDate { get; set; }


        [ForeignKey("Id")]
        public virtual IEnumerable<AppUserLog> AppUserLogs { get; set; }
    }

    public class AppUserLog : BaseEntity
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int AppUserId { get; set; }
        public string IpAddress { get; set; }
        public string Description { get; set; }
    }
}
