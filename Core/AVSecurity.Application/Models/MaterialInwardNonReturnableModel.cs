﻿using AVSecurity.Domain.Entities;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AVSecurity.Application.Models
{
    public class MaterialInwardNonReturnableModel
    {
    }

    public class MaterialInwardNonReturnable_Request : BaseEntity
    {
        public MaterialInwardNonReturnable_Request()
        {
            challanList = new List<MaterialInwardNonReturnableChallan_Request>(); 
        }
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? SenderCompanyName { get; set; }
        public string? SenderName { get; set; }
        public string? Address { get; set; }
        public string? TransporterCompanyName { get; set; }
        public string? NatureOfSupply { get; set; }
        public string? PONumber { get; set; }
        public string? MaterialName { get; set; }
        public int? Quantity { get; set; }
        public string? Serialno { get; set; }
        public string? Assetno { get; set; }
        public int? MaterialStatusId { get; set; }
        public string? Remarks { get; set; }
        public List<MaterialInwardNonReturnableChallan_Request> challanList { get; set; }
    }

    public class MaterialInwardNonReturnable_Response : BaseResponseEntity
    {
        public MaterialInwardNonReturnable_Response()
        {
            challanList = new List<MaterialInwardNonReturnableChallan_Response>();
        }
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmailId { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? SenderCompanyName { get; set; }
        public string? SenderName { get; set; }
        public string? Address { get; set; }
        public string? TransporterCompanyName { get; set; }
        public string? NatureOfSupply { get; set; }
        public string? PONumber { get; set; }
        public string? MaterialName { get; set; }
        public int? Quantity { get; set; }
        public string? Serialno { get; set; }
        public string? Assetno { get; set; }
        public int? MaterialStatusId { get; set; }
        public string? MaterialStatusName { get; set; }
        public string? Remarks { get; set; }
        public List<MaterialInwardNonReturnableChallan_Response> challanList { get; set; }
    }

    public class MaterialInwardNonReturnableChallan_Request : BaseEntity
    {
        [JsonIgnore]
        public int? MaterialInwardNonReturnableId { get; set; }

        [DefaultValue("")]
        public string? ChallanNumber { get; set; }

        [DefaultValue("")]
        public string? ChallanOriginalFileName { get; set; }

        [JsonIgnore]
        public string? ChallanImage { get; set; }

        [DefaultValue("")]
        public string? ChallanImage_Base64 { get; set; }
    }

    public class MaterialInwardNonReturnableChallan_Response : BaseResponseEntity
    {
        public int? MaterialInwardNonReturnableId { get; set; }
        public string? ChallanNumber { get; set; }
        public string? ChallanImage { get; set; }
        public string? ChallanOriginalFileName { get; set; }
        public string? ChallanImageURL { get; set; }
    }

    public class MaterialInwardNonReturnableSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }

    public class MaterialInwardNonReturnableChallanSearch_Request : BaseSearchEntity
    {
        [DefaultValue(0)]
        public int? MaterialInwardNonReturnableId { get; set; }
    }
}
