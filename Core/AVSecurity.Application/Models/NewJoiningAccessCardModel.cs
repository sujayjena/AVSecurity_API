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
    public class NewJoiningAccessCardModel
    {
    }

    public class NewJoiningAccessCard_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EID { get; set; }
        public int? BloodGroupId { get; set; }
        public int? EmployeeTypeId { get; set; }
        public int? GenderId { get; set; }
        public string? IDNo { get; set; }
        public string? Remarks { get; set; }
    }

    public class NewJoiningAccessCard_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EID { get; set; }
        public int? BloodGroupId { get; set; }
        public string? BloodGroup { get; set; }
        public int? EmployeeTypeId { get; set; }
        public string? EmployeeTypeName { get; set; }
        public int? GenderId { get; set; }
        public string? GenderName { get; set; }
        public string? IDNo { get; set; }
        public string? Remarks { get; set; }
    }
    public class NewJoiningAccessCardSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
