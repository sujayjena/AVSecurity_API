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
    public class MasterAccessCardModel
    {
    }
    public class MasterAccessCard_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? IssuedToId { get; set; }
        public string? CardNumber { get; set; }
        public DateTime? CardReturnDate { get; set; }
    }

    public class MasterAccessCard_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? IssuedToId { get; set; }
        public string? IssuedTo { get; set; }
        public string? CardNumber { get; set; }
        public DateTime? CardReturnDate { get; set; }
    }
    public class MasterAccessCardSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
