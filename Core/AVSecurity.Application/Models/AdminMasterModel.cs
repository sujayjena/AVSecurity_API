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
}
