using AVSecurity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Models
{
    public class BadgesMissingModel
    {
    }

    public class BadgesMissing_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? BadgesMissingDate { get; set; }
        public string? EmployeeType { get; set; }
        public int? EmployeeId { get; set; }
        public int? VisitorTypeId { get; set; }
        public int? ReasonTypeId { get; set; }
        public string? BadgeDesc { get; set; }
        public string? BadgeNo { get; set; }
        public DateTime? BadgeLostDate { get; set; }
    }

    public class BadgesMissing_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? BadgesMissingDate { get; set; }
        public string? EmployeeType { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int? VisitorTypeId { get; set; }
        public string? VisitorTypeName { get; set; }
        public int? ReasonTypeId { get; set; }
        public string? ReasonTypeName { get; set; }
        public string? BadgeDesc { get; set; }
        public string? BadgeNo { get; set; }
        public DateTime? BadgeLostDate { get; set; }
    }
}
