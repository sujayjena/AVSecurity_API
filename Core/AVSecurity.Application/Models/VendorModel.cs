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
    public class VendorModel
    {
    }
    public class Vendor_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? VendorName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobileNo { get; set; }
        public int? VisitPurposeId { get; set; }
        public string? BadgeNo { get; set; }
        public string? Remarks { get; set; }
    }

    public class Vendor_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? VendorName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MobileNo { get; set; }
        public int? VisitPurposeId { get; set; }
        public string? VisitPurposeName { get; set; }
        public string? BadgeNo { get; set; }
        public string? Remarks { get; set; }
    }
    public class VendorSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
