using System.ComponentModel.DataAnnotations;

namespace EnesKartalCom.Areas.Applications.Models
{
    public class MailConfigInput
    {
        public int Id { get; set; }
        public string ConfigName { get; set; }
        public int UserId { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public string DefaultFromName { get; set; }
    }
}
