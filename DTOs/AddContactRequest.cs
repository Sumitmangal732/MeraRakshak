using System.ComponentModel.DataAnnotations;

namespace MeraRakshak.DTOs
{
    public class AddContactRequest
    {
        [Required]
        public string Token { get; set; } = string.Empty;

        [Required]
        public string CallerName { get; set; } = string.Empty;

        [Required]
        public string CallerNo { get; set; } = string.Empty;

        public string? CallerImg { get; set; }

        public string? DeviceModel { get; set; }
    }
}
