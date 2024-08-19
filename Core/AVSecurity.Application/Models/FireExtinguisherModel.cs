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
    public class FireExtinguisherModel
    {
    }
    public class FireExtinguisher_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? FireEDate { get; set; }
        public int? EmployeeId { get; set; }
        public string? PhoneNumber { get; set; }
        public int? LocationId { get; set; }
        public int? InspectedById { get; set; }
        public int? InformedToId { get; set; }
    }

    public class FireExtinguisher_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? FireEDate { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? PhoneNumber { get; set; }
        public int? LocationId { get; set; }
        public string? LocationName { get; set; }
        public int? InspectedById { get; set; }
        public string? InspectedBy { get; set; }
        public int? InformedToId { get; set; }
        public string? InformedTo { get; set; }
    }

    public class FireExtinguisherSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
