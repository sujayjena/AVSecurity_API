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
    public class AccessDoorChecklistModel
    {
    }
    public class AccessDoorChecklist_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? AccesDoorDate { get; set; }
        public int? LocationId { get; set; }
        public int? BuildingId { get; set; }
        public int? FloorId { get; set; }

        [DefaultValue(false)]
        public bool? IsInReaderStatus { get; set; }

        [DefaultValue(false)]
        public bool? IsInPushButtonStatus { get; set; }

        [DefaultValue(false)]
        public bool? IsOutReaderStatus { get; set; }

        [DefaultValue(false)]
        public bool? IsOutPushButtonStatus { get; set; }

        [DefaultValue(false)]
        public bool? IsElectroMagneticLockStatus { get; set; }

        [DefaultValue(false)]
        public bool? IsDoorAlignment { get; set; }

        [DefaultValue(false)]
        public bool? IsFaulty { get; set; }
        public string? ExpenseDesc { get; set; }
        public int? ReportedToId { get; set; }

        [DefaultValue(false)]
        public bool? IsNotificationToAdmin { get; set; }
    }

    public class AccessDoorChecklist_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? AccesDoorDate { get; set; }
        public int? LocationId { get; set; }
        public string? LocationName { get; set; }
        public int? BuildingId { get; set; }
        public string? BuildingName { get; set; }
        public int? FloorId { get; set; }
        public string? FloorName { get; set; }
        public bool? IsInReaderStatus { get; set; }
        public bool? IsInPushButtonStatus { get; set; }
        public bool? IsOutReaderStatus { get; set; }
        public bool? IsOutPushButtonStatus { get; set; }
        public bool? IsElectroMagneticLockStatus { get; set; }
        public bool? IsDoorAlignment { get; set; }
        public bool? IsFaulty { get; set; }
        public string? ExpenseDesc { get; set; }
        public int? ReportedToId { get; set; }
        public string? ReportedTo { get; set; }
        public bool? IsNotificationToAdmin { get; set; }
    }

    public class AccessDoorChecklistSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
