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
    public class VehicleEntryChecklistModel
    {
    }

    public class VehicleEntryChecklist_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? VehicleTypeId { get; set; }
        public string? VehicleNumber { get; set; }
        public DateTime? OutDate { get; set; }
        public int? EmployeeId { get; set; }
        public string? Remarks { get; set; }
    }

    public class VehicleEntryChecklist_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? VehicleTypeId { get; set; }
        public string? VehicleTypeName { get; set; }
        public string? VehicleNumber { get; set; }
        public DateTime? OutDate { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? Remarks { get; set; }
    }
    public class VehicleEntryChecklistSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}

