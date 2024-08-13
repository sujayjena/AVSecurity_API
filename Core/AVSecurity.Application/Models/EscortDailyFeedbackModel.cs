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
    public class EscortDailyFeedbackModel
    {
    }
    public class EscortDailyFeedback_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }
        public int? RouteId { get; set; }

        [DefaultValue(false)]
        public bool? IsUsingMobileWhileDriving { get; set; }

        [DefaultValue(false)]
        public bool? IsDrivingRash { get; set; }

        [DefaultValue(false)]
        public bool? IsFollowedTrafficRules { get; set; }

        [DefaultValue(false)]
        public bool? IsPoliteToEmployee { get; set; }

        [DefaultValue(false)]
        public bool? IsSecurityGuardAlert { get; set; }

        [DefaultValue(false)]
        public bool? IsPepperOrChillySprayIssued { get; set; }
        public string? Remarks { get; set; }
    }

    public class EscortDailyFeedback_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int? RouteId { get; set; }
        public string? RouteName { get; set; }
        public bool? IsUsingMobileWhileDriving { get; set; }
        public bool? IsDrivingRash { get; set; }
        public bool? IsFollowedTrafficRules { get; set; }
        public bool? IsPoliteToEmployee { get; set; }
        public bool? IsSecurityGuardAlert { get; set; }
        public bool? IsPepperOrChillySprayIssued { get; set; }
        public string? Remarks { get; set; }
    }
    public class EscortDailyFeedbackSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
