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
    public class AttendanceRegisterModel
    {
    }

    public class AttendanceRegister_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateInTime { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? DateOutTime { get; set; }
        public string? Remarks { get; set; }
    }

    public class AttendanceRegister_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateInTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime? DateOutTime { get; set; }
        public string? Remarks { get; set; }
    }

    public class AttendanceRegisterSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
