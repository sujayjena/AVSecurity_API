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
    public class OvernightParkingModel
    {
    }
    public class OvernightParking_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? VehicleTypeId { get; set; }
        public string? VehicleNo { get; set; }
        public string? VehicleCondition { get; set; }
        public string? ParkedArea { get; set; }
        public string? Remarks { get; set; }

        [DefaultValue(false)]
        public bool? IsNotificationToAdmin { get; set; }
    }

    public class OvernightParking_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? VehicleTypeId { get; set; }
        public string? VehicleTypeName { get; set; }
        public string? VehicleNo { get; set; }
        public string? VehicleCondition { get; set; }
        public string? ParkedArea { get; set; }
        public string? Remarks { get; set; }
        public bool? IsNotificationToAdmin { get; set; }
    }
    public class OvernightParkingSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}

