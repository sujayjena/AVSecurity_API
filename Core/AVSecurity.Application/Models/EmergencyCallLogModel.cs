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
    public class EmergencyCallLogModel
    {
    }
    public class EmergencyCallLog_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? ReportedBy { get; set; }
        public string? CallDetails { get; set; }
        public int? ReceivedById { get; set; }
        public int? EmergencyTypeId { get; set; }
        public string? EmergencyDesc { get; set; }
        public int? EmergencyClosureId { get; set; }
        public string? ActionToken { get; set; }
    }

    public class EmergencyCallLog_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? ReportedBy { get; set; }
        public string? CallDetails { get; set; }
        public int? ReceivedById { get; set; }
        public string? ReceivedBy { get; set; }
        public int? EmergencyTypeId { get; set; }
        public string? EmergencyTypeName { get; set; }
        public string? EmergencyDesc { get; set; }
        public int? EmergencyClosureId { get; set; }
        public string? EmergencyClosureName { get; set; }
        public string? ActionToken { get; set; }
    }
    public class EmergencyCallLogSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
