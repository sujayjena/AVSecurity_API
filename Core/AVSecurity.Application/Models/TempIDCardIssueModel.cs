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
    public class TempIDCardIssueModel
    {
    }
    public class TempIDCardIssue_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? IDCardNo { get; set; }
        public string? ReasonForIssuance { get; set; }
        public string? Descriptions { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? Remarks { get; set; }
    }

    public class TempIDCardIssue_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? IDCardNo { get; set; }
        public string? ReasonForIssuance { get; set; }
        public string? Descriptions { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? Remarks { get; set; }
    }
    public class TempIDCardIssueSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
