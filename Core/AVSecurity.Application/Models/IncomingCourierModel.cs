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
    public class IncomingCourierModel
    {
    }

    public class IncomingCourier_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? FromCompany { get; set; }
        public string? Address { get; set; }
        public string? FromCity { get; set; }
        public string? Pincode { get; set; }
        public string? CourierName { get; set; }
        public string? AirwayBillNo { get; set; }

        [DefaultValue(false)]
        public bool? IsNotifyToEmployee { get; set; }
    }

    public class IncomingCourier_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? FromCompany { get; set; }
        public string? Address { get; set; }
        public string? FromCity { get; set; }
        public string? Pincode { get; set; }
        public string? CourierName { get; set; }
        public string? AirwayBillNo { get; set; }

        [DefaultValue(false)]
        public bool? IsNotifyToEmployee { get; set; }
    }
    public class IncomingCourierSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
