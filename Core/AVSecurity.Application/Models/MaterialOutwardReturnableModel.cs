using AVSecurity.Domain.Entities;
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
    public class MaterialOutwardReturnableModel
    {
    }

    public class MaterialOutwardReturnable_Request : BaseEntity
    {
        public MaterialOutwardReturnable_Request()
        {
            challanList = new List<MaterialOutwardReturnableChallan_Request>();
        }
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? ReceiverCompanyName { get; set; }
        public string? ReceiverName { get; set; }
        public string? Address { get; set; }
        public string? TransporterCompanyName { get; set; }
        public string? NatureOfSupply { get; set; }
        public string? PONumber { get; set; }
        public string? MaterialName { get; set; }
        public int? Quantity { get; set; }
        public string? Serialno { get; set; }
        public string? Assetno { get; set; }

        [DefaultValue(null)]
        public DateTime? ReturnableDate { get; set; }
        public int? MaterialStatusId { get; set; }
        public string? Remarks { get; set; }
        public List<MaterialOutwardReturnableChallan_Request> challanList { get; set; }
    }

    public class MaterialOutwardReturnable_Response : BaseResponseEntity
    {
        public MaterialOutwardReturnable_Response()
        {
            challanList = new List<MaterialOutwardReturnableChallan_Response>();
        }
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmailId { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? ReceiverCompanyName { get; set; }
        public string? ReceiverName { get; set; }
        public string? Address { get; set; }
        public string? TransporterCompanyName { get; set; }
        public string? NatureOfSupply { get; set; }
        public string? PONumber { get; set; }
        public string? MaterialName { get; set; }
        public int? Quantity { get; set; }
        public string? Serialno { get; set; }
        public string? Assetno { get; set; }
        public DateTime? ReturnableDate { get; set; }
        public int? MaterialStatusId { get; set; }
        public string? MaterialStatusName { get; set; }
        public string? Remarks { get; set; }
        public List<MaterialOutwardReturnableChallan_Response> challanList { get; set; }
    }

    public class MaterialOutwardReturnableChallan_Request : BaseEntity
    {
        [JsonIgnore]
        public int? MaterialOutwardReturnableId { get; set; }

        [DefaultValue("")]
        public string? ChallanNumber { get; set; }

        [DefaultValue("")]
        public string? ChallanOriginalFileName { get; set; }

        [JsonIgnore]
        public string? ChallanImage { get; set; }

        [DefaultValue("")]
        public string? ChallanImage_Base64 { get; set; }
    }

    public class MaterialOutwardReturnableChallan_Response : BaseResponseEntity
    {
        public int? MaterialOutwardReturnableId { get; set; }
        public string? ChallanNumber { get; set; }
        public string? ChallanImage { get; set; }
        public string? ChallanOriginalFileName { get; set; }
        public string? ChallanImageURL { get; set; }
    }

    public class MaterialOutwardReturnableSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }

    public class MaterialOutwardReturnableChallanSearch_Request : BaseSearchEntity
    {
        [DefaultValue(0)]
        public int? MaterialOutwardReturnableId { get; set; }
    }
}

