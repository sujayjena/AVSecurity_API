using AVSecurity.Domain.Entities;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class KeySearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
