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
    public class NewsPaperModel
    {
    }
    public class NewsPaper_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? ServiceProvider { get; set; }
        public string? DeliveryPersonName { get; set; }
        public string? DeliveryPersonMobileNo { get; set; }

        [DefaultValue(false)]
        public bool? IsTimesOfIndia { get; set; }

        [DefaultValue(false)]
        public bool? IsEconomicTimes { get; set; }

        [DefaultValue(false)]
        public bool? IsBusinessStandard { get; set; }
        public int? NoofNewsPaper { get; set; }

        [DefaultValue(false)]
        public bool? IsNotificationToAdmin { get; set; }
    }

    public class NewsPaper_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? ServiceProvider { get; set; }
        public string? DeliveryPersonName { get; set; }
        public string? DeliveryPersonMobileNo { get; set; }

        [DefaultValue(false)]
        public bool? IsTimesOfIndia { get; set; }

        [DefaultValue(false)]
        public bool? IsEconomicTimes { get; set; }

        [DefaultValue(false)]
        public bool? IsBusinessStandard { get; set; }
        public int? NoofNewsPaper { get; set; }
        public bool? IsNotificationToAdmin { get; set; }
    }
    public class NewsPaperSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
