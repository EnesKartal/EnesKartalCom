using System.ComponentModel.DataAnnotations;

namespace EnesKartalCom.Areas.Applications.Models
{
    public class MailInput
    {
        //bu arkadaşa henüz sıra gelmedi :D
        public string[] Receivers { get; set; }
        [UIHint("Textarea")]
        public string Body { get; set; }
        [UIHint("String")]
        public string Subject { get; set; }
        [UIHint("CheckBox")]
        public bool IsBodyHtml { get; set; }
        [UIHint("String")]
        public string FromName { get; set; }
        //name attribute yok sanırım daha ona bakcaz sonra s.et
        [Required(ErrorMessage ="{0} Alanı zorunludur")]
        [UIHint("Dropdown")]
        public int ConfigId { get; set; }
    }
}
