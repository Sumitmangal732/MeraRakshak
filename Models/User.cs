using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeraRakshak.Models
{
    [Table("UserMaster")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string? FullName { get; set; }

        [MaxLength(200)]
        public string? EmailAddress { get; set; }

        [MaxLength(10)]
        public string? MobileNumber { get; set; }

        [MaxLength(50)]
        public string? Password { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(100)]
        public string? DeviceId { get; set; }

        [MaxLength(100)]
        public string? DeviceModelName { get; set; }
    }
}
