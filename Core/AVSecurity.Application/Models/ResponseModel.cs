using System.ComponentModel;

namespace AVSecurity.Application.Models
{
    public class ResponseModel
    {
        public bool? IsSuccess { get; set; }
        public string? Message { get; set; }

        [DefaultValue(0)]
        public long Total { get; set; }
        public object Data { get; set; }
    }
}
