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
    public class WaterCanModel
    {
    }
    public class WaterCan_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? ServiceProvider { get; set; }
        public string? DeliveryPersonName { get; set; }
        public string? DeliveryPersonMobileNo { get; set; }
        public int? NoOfWaterCanDelivered { get; set; }
        public int? NoOfWaterEmptyCanTaken { get; set; }

        [DefaultValue(false)]
        public bool? IsNotificationToAdmin { get; set; }
    }

    public class WaterCan_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? ServiceProvider { get; set; }
        public string? DeliveryPersonName { get; set; }
        public string? DeliveryPersonMobileNo { get; set; }
        public int? NoOfWaterCanDelivered { get; set; }
        public int? NoOfWaterEmptyCanTaken { get; set; }

        [DefaultValue(false)]
        public bool? IsNotificationToAdmin { get; set; }
    }
    public class WaterCanSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
