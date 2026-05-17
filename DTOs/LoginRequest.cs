using System.ComponentModel.DataAnnotations;

namespace MeraRakshak.DTOs
{
    public class LoginRequest
    {
        [Required]
        public string UserNameOrMobileNo { get; set; }

        [Required]
        public string Password { get; set; }

        public string ImeiNo { get; set; }

        public string DeviceModel { get; set; }
    }
}
