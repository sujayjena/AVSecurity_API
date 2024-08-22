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
    public class PAChecklistModel
    {
    }

    public class PAChecklist_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? LocationId { get; set; }
        public int? BuildingId { get; set; }
        public int? FloorId { get; set; }
        public string? Audibility_WS_Area { get; set; }
        public int? ReportedToId { get; set; }

        [DefaultValue(null)]
        public DateTime? RectificationDate { get; set; }
        public string? Remarks { get; set; }
    }

    public class PAChecklist_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? LocationId { get; set; }
        public string? LocationName { get; set; }
        public int? BuildingId { get; set; }
        public string? BuildingName { get; set; }
        public int? FloorId { get; set; }
        public string? FloorName { get; set; }
        public string? Audibility_WS_Area { get; set; }
        public int? ReportedToId { get; set; }
        public string? ReportedTo { get; set; }
        public DateTime? RectificationDate { get; set; }
        public string? Remarks { get; set; }
    }
    public class PAChecklistSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
