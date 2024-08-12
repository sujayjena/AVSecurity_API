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
    public class CCTVMonitoringModel
    {
    }
    public class CCTVMonitoring_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? CCTVMonitoringDate { get; set; }
        public int? DvmServerId { get; set; }
        public int? EbiServerId { get; set; }

        [DefaultValue(false)]
        public bool? IsTimeSync { get; set; }
        public string? DiffBWSyncTime { get; set; }
        public DateTime? SyncDiffResolvedDate { get; set; }

        [DefaultValue(false)]
        public bool? IsTimeSyncOnDifferenceResolved { get; set; }

        [DefaultValue(false)]
        public bool? IsCCTV1_FeedCheck { get; set; }

        [DefaultValue(false)]
        public bool? IsCCTV2_FeedCheck { get; set; }

        [DefaultValue(false)]
        public bool? IsCCTV3_FeedCheck { get; set; }
        public string? Remarks { get; set; }
    }

    public class CCTVMonitoring_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? CCTVMonitoringDate { get; set; }
        public int? DvmServerId { get; set; }
        public string? DvmServerName { get; set; }
        public int? EbiServerId { get; set; }
        public string? EbiServerName { get; set; }
        public bool? IsTimeSync { get; set; }
        public string? DiffBWSyncTime { get; set; }
        public DateTime? SyncDiffResolvedDate { get; set; }
        public bool? IsTimeSyncOnDifferenceResolved { get; set; }
        public bool? IsCCTV1_FeedCheck { get; set; }
        public bool? IsCCTV2_FeedCheck { get; set; }
        public bool? IsCCTV3_FeedCheck { get; set; }
        public string? Remarks { get; set; }
    }

    public class CCTVMonitoringSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
