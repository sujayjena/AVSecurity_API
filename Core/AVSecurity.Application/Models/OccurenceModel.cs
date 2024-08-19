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
    public class OccurenceModel
    {
    }
    public class Occurence_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? ReportedBy { get; set; }
        public int? EventTypeId { get; set; }
        public string? EventDesc { get; set; }
    }

    public class Occurence_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? ReportedBy { get; set; }
        public int? EventTypeId { get; set; }
        public string? EventTypeName { get; set; }
        public string? EventDesc { get; set; }
    }
    public class OccurenceSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
