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
    public class MilkModel
    {
    }
    public class Milk_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? EmailId { get; set; }
        public string? DCNumber { get; set; }
        public string? ServiceProvider { get; set; }
        public string? DeliveryPersonName { get; set; }
        public string? DeliveryPersonMobileNo { get; set; }
        public int? NoofPacket { get; set; }

        [DefaultValue(false)]
        public bool? IsNotificationToAdmin { get; set; }
    }

    public class Milk_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? EmailId { get; set; }
        public string? DCNumber { get; set; }
        public string? ServiceProvider { get; set; }
        public string? DeliveryPersonName { get; set; }
        public string? DeliveryPersonMobileNo { get; set; }
        public int? NoofPacket { get; set; }
        public bool? IsNotificationToAdmin { get; set; }
    }
    public class MilkSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
