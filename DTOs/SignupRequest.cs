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
        [MaxLength(10)]
        public string MobileNumber { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        public string? Address { get; set; }

        [Required]
        public string DeviceId { get; set; } = string.Empty;

        [Required]
        public string DeviceModelName { get; set; } = string.Empty;
    }
}
