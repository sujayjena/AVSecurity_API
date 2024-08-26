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
    public class WorkspaceChecklistModel
    {
    }
    public class WorkspaceChecklist_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? RequestNo { get; set; }
        public string? RequesterName { get; set; }
        public string? WorkLocation { get; set; }
        public string? WorkDescription { get; set; }
        public int? ApprovedById { get; set; }
        public string? WorkPermitNo { get; set; }
        public string? VendorName { get; set; }
        public DateTime? WorkExecutionDate { get; set; }

        [DefaultValue(false)]
        public bool? IsAfterWorkCleaning { get; set; }
        public string? Remarks { get; set; }
    }

    public class WorkspaceChecklist_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? RequestNo { get; set; }
        public string? RequesterName { get; set; }
        public string? WorkLocation { get; set; }
        public string? WorkDescription { get; set; }
        public int? ApprovedById { get; set; }
        public string? ApprovedByName { get; set; }
        public string? WorkPermitNo { get; set; }
        public string? VendorName { get; set; }
        public DateTime? WorkExecutionDate { get; set; }

        [DefaultValue(false)]
        public bool? IsAfterWorkCleaning { get; set; }
        public string? Remarks { get; set; }
    }
    public class WorkspaceChecklistSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
