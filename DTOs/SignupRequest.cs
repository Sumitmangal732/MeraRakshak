using System.ComponentModel.DataAnnotations;

namespace MeraRakshak.DTOs
{
    public class SignupRequest
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        public string MobileNo { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public string? Address { get; set; }

        [Required]
        public string ImeiNo { get; set; } = string.Empty;

        [Required]
        public string DeviceModel { get; set; } = string.Empty;
    }
}
