using System.ComponentModel.DataAnnotations;

namespace MeraRakshak.DTOs
{
    public class AddCallLogsRequest
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public string CallerName { get; set; }

        [Required]
        public string CallerNo { get; set; }

        public string CallType { get; set; }

        public string CallDuration { get; set; }

        public DateTime DateTime { get; set; }

        public string ImeiNo { get; set; }

        public string DeviceModel { get; set; }
    }
}
