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
    public class OutgoingCourierModel
    {
    }
    public class OutgoingCourier_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? ToCompany { get; set; }
        public string? Address { get; set; }
        public string? ToCity { get; set; }
        public string? Pincode { get; set; }
        public int? CourierNameId { get; set; }
        public string? AirwayBillNo { get; set; }
        public DateTime? DispatchedDate { get; set; }

        [DefaultValue(false)]
        public bool? IsNotificationToAdmin { get; set; }
    }

    public class OutgoingCourier_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? ToCompany { get; set; }
        public string? Address { get; set; }
        public string? ToCity { get; set; }
        public string? Pincode { get; set; }
        public int? CourierNameId { get; set; }
        public string? CourierName { get; set; }
        public string? AirwayBillNo { get; set; }
        public DateTime? DispatchedDate { get; set; }
        public bool? IsNotificationToAdmin { get; set; }
    }
    public class OutgoingCourierSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
