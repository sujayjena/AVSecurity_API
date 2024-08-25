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
    public class SecurityIncidentModel
    {
    }

    public class SecurityIncident_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? ReportedBy { get; set; }
        public int? IncidentTypeId { get; set; }
        public string? IncidentDesc { get; set; }
        public string? IncidentReportTo { get; set; }
        public string? IncidentClosureBy { get; set; }
        public string? ActionTaken { get; set; }
    }

    public class SecurityIncident_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? ReportedBy { get; set; }
        public int? IncidentTypeId { get; set; }
        public string? IncidentTypeName { get; set; }
        public string? IncidentDesc { get; set; }
        public string? IncidentReportTo { get; set; }
        public string? IncidentClosureBy { get; set; }
        public string? ActionTaken { get; set; }
    }
    public class SecurityIncidentSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
