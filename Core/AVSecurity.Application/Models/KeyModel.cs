using AVSecurity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Models
{
    public class KeyModel
    {
    }

    public class Key_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? KeyIssuedToId { get; set; }
        public string? Key { get; set; }
        public DateTime? KeyReturnDate { get; set; }
    }

    public class Key_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? KeyIssuedToId { get; set; }
        public string? KeyIssuedTo { get; set; }
        public string? Key { get; set; }
        public DateTime? KeyReturnDate { get; set; }
    }
}
