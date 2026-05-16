using System.ComponentModel.DataAnnotations;

namespace MeraRakshak.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string MobileNo { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string ImeiNo { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string DeviceModel { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
