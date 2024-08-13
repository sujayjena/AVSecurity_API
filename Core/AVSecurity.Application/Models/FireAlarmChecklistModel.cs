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
    public class FireAlarmChecklistModel
    {
    }
    public class FireAlarmChecklist_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? LocationId { get; set; }
        public int? BuildingId { get; set; }
        public int? FloorId { get; set; }
        public string? LoopDeviceNumber { get; set; }
        public string? Sounder { get; set; }
        public string? Display { get; set; }
        public string? Remarks { get; set; }
        public int? VerifiedId { get; set; }
        public DateTime? VerifiedDate { get; set; }
    }

    public class FireAlarmChecklist_Response : BaseResponseEntity
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
        public string? LoopDeviceNumber { get; set; }
        public string? Sounder { get; set; }
        public string? Display { get; set; }
        public string? Remarks { get; set; }
        public int? VerifiedId { get; set; }
        public string? VerifiedName { get; set; }
        public DateTime? VerifiedDate { get; set; }
    }
    public class FireAlarmChecklistSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
