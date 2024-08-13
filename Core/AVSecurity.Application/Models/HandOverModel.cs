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
    public class HandOverModel
    {
    }
    public class HandOver_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? HandOverDate { get; set; }
        public int? EmployeeId { get; set; }
        public string? DutyBriefingAndRemarks { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? ToEmployeeId { get; set; }
        public int? FromEmployeeId { get; set; }
        public string? CourierName { get; set; }
        public string? AirwayBillNumber { get; set; }
        public int? ReceivedById { get; set; }
    }

    public class HandOver_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? HandOverDate { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? MobileNumber { get; set; }
        public string? DutyBriefingAndRemarks { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? ToEmployeeId { get; set; }
        public string? ToEmployee { get; set; }
        public int? FromEmployeeId { get; set; }
        public string? FromEmployee { get; set; }
        public string? CourierName { get; set; }
        public string? AirwayBillNumber { get; set; }
        public int? ReceivedById { get; set; }
        public string? ReceivedBy { get; set; }
    }

    public class HandOverSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
