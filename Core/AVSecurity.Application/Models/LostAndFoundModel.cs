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
    public class LostAndFoundModel
    {
    }
    public class LostAndFound_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? ItemName { get; set; }
        public string? FoundByName { get; set; }
        public string? FoundLocation { get; set; }
        public DateTime? ItemHandoverDate { get; set; }
        public int? ReceiverId { get; set; }
        public string? ReceiverIDNo { get; set; }
        public string? Remarks { get; set; }

        [DefaultValue(false)]
        public bool? IsNotificationToAdmin { get; set; }
    }

    public class LostAndFound_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? ItemName { get; set; }
        public string? FoundByName { get; set; }
        public string? FoundLocation { get; set; }
        public DateTime? ItemHandoverDate { get; set; }
        public int? ReceiverId { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverIDNo { get; set; }
        public string? Remarks { get; set; }
        public bool? IsNotificationToAdmin { get; set; }
    }
    public class LostAndFoundSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
