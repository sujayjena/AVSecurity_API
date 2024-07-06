using AVSecurity.Domain.Entities;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AVSecurity.Application.Models
{
    #region Location

    public class Location_Search : BaseSearchEntity
    {
    }

    public class Location_Request : BaseEntity
    {
        public string? LocationName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class Location_Response : BaseResponseEntity
    {
        public string? LocationName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region Building

    public class Building_Search : BaseSearchEntity
    {
    }

    public class Building_Request : BaseEntity
    {
        public string? BuildingName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class Building_Response : BaseResponseEntity
    {
        public string? BuildingName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region Floor

    public class Floor_Search : BaseSearchEntity
    {
    }

    public class Floor_Request : BaseEntity
    {
        public string? FloorName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class Floor_Response : BaseResponseEntity
    {
        public string? FloorName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region ReasonType

    public class ReasonType_Search : BaseSearchEntity
    {
    }

    public class ReasonType_Request : BaseEntity
    {
        public string? ReasonTypeName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class ReasonType_Response : BaseResponseEntity
    {
        public string? ReasonTypeName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region VisitorType

    public class VisitorType_Search : BaseSearchEntity
    {
    }

    public class VisitorType_Request : BaseEntity
    {
        public string? VisitorTypeName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class VisitorType_Response : BaseResponseEntity
    {
        public string? VisitorTypeName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region DvmServer

    public class DvmServer_Search : BaseSearchEntity
    {
    }

    public class DvmServer_Request : BaseEntity
    {
        public string? DvmServerName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class DvmServer_Response : BaseResponseEntity
    {
        public string? DvmServerName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region EbiServer

    public class EbiServer_Search : BaseSearchEntity
    {
    }

    public class EbiServer_Request : BaseEntity
    {
        public string? EbiServerName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class EbiServer_Response : BaseResponseEntity
    {
        public string? EbiServerName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region EmergencyType

    public class EmergencyType_Search : BaseSearchEntity
    {
    }

    public class EmergencyType_Request : BaseEntity
    {
        public string? EmergencyTypeName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class EmergencyType_Response : BaseResponseEntity
    {
        public string? EmergencyTypeName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region EmergencyClosure

    public class EmergencyClosure_Search : BaseSearchEntity
    {
    }

    public class EmergencyClosure_Request : BaseEntity
    {
        public string? EmergencyClosureName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class EmergencyClosure_Response : BaseResponseEntity
    {
        public string? EmergencyClosureName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region Shift

    public class Shift_Search : BaseSearchEntity
    {
    }

    public class Shift_Request : BaseEntity
    {
        public string? ShiftName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class Shift_Response : BaseResponseEntity
    {
        public string? ShiftName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region Route

    public class Route_Search : BaseSearchEntity
    {
    }

    public class Route_Request : BaseEntity
    {
        public string? RouteName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class Route_Response : BaseResponseEntity
    {
        public string? RouteName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region Verified

    public class Verified_Search : BaseSearchEntity
    {
    }

    public class Verified_Request : BaseEntity
    {
        public string? VerifiedName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class Verified_Response : BaseResponseEntity
    {
        public string? VerifiedName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region MeritalStatus

    public class MeritalStatus_Search : BaseSearchEntity
    {
    }

    public class MeritalStatus_Request : BaseEntity
    {
        public string? MeritalStatusName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class MeritalStatus_Response : BaseResponseEntity
    {
        public string? MeritalStatusName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region EmployeeType

    public class EmployeeType_Search : BaseSearchEntity
    {
    }

    public class EmployeeType_Request : BaseEntity
    {
        public string? EmployeeTypeName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class EmployeeType_Response : BaseResponseEntity
    {
        public string? EmployeeTypeName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion

    #region Gender

    public class Gender_Search : BaseSearchEntity
    {
    }

    public class Gender_Request : BaseEntity
    {
        public string? GenderName { get; set; }

        public bool? IsActive { get; set; }
    }

    public class Gender_Response : BaseResponseEntity
    {
        public string? GenderName { get; set; }

        public bool? IsActive { get; set; }
    }

    #endregion
}
