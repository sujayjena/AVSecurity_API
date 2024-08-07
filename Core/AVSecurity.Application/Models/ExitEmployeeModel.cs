﻿using AVSecurity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Models
{
    public class ExitEmployeeModel
    {
    }

    public class ExitEmployee_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }

        [DefaultValue(false)]
        public bool? IsBadgeHandedOver { get; set; }

        [DefaultValue(false)]
        public bool? IsMaterialsCarried { get; set; }
        public string? YesDesc { get; set; }
        public string? AnyObservations { get; set; }
        public string? VehicleNo { get; set; }
    }

    public class ExitEmployee_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public bool? IsBadgeHandedOver { get; set; }
        public bool? IsMaterialsCarried { get; set; }
        public string? YesDesc { get; set; }
        public string? AnyObservations { get; set; }
        public string? VehicleNo { get; set; }
    }
}
