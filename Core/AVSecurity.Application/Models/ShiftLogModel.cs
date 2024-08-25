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
    public class ShiftLogModel
    {
    }

    public class ShiftLog_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? HandedOverById { get; set; }
        public int? HandedOverToId { get; set; }

        [DefaultValue(false)]
        public bool? IsCheckComplaintAndActionTaken { get; set; }

        [DefaultValue(false)]
        public bool? IsCheckAllUPSParameters { get; set; }

        [DefaultValue(false)]
        public bool? IsCheckTransformerProperWorking { get; set; }

        [DefaultValue(false)]
        public bool? IsCheckLightFitting { get; set; }

        [DefaultValue(false)]
        public bool? IsCheckAllLTPanels { get; set; }

        [DefaultValue(false)]
        public bool? IsCheckAllElevators { get; set; }

        [DefaultValue(false)]
        public bool? IsCheckAirCompressorProperWorking { get; set; }

        [DefaultValue(false)]
        public bool? IsCheckDGParameter { get; set; }

        [DefaultValue(false)]
        public bool? IsCheckSwitchOnOffAllCommonAreaLight { get; set; }

        [DefaultValue(false)]
        public bool? IsRegulateFloorLighting { get; set; }
    }

    public class ShiftLog_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? HandedOverById { get; set; }
        public string? HandedOverByName { get; set; }
        public int? HandedOverToId { get; set; }
        public string? HandedOverToName { get; set; }
        public bool? IsCheckComplaintAndActionTaken { get; set; }
        public bool? IsCheckAllUPSParameters { get; set; }
        public bool? IsCheckTransformerProperWorking { get; set; }
        public bool? IsCheckLightFitting { get; set; }
        public bool? IsCheckAllLTPanels { get; set; }
        public bool? IsCheckAllElevators { get; set; }
        public bool? IsCheckAirCompressorProperWorking { get; set; }
        public bool? IsCheckDGParameter { get; set; }
        public bool? IsCheckSwitchOnOffAllCommonAreaLight { get; set; }
        public bool? IsRegulateFloorLighting { get; set; }
    }
    public class ShiftLogSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
