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
    public class PersonalBelongingModel
    {
    }

    public class PersonalBelonging_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? PBBelongsToId { get; set; }
        public int? PBTypeId { get; set; }
        public string? PBDesc { get; set; }
        public string? PigeonSlotNumber { get; set; }

        [DefaultValue(null)]
        public DateTime? PBReturnDate { get; set; }
    }

    public class PersonalBelonging_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public int? PBBelongsToId { get; set; }
        public string? PBBelongsTo { get; set; }
        public string? PBBelongsEmailId { get; set; }
        public int? PBTypeId { get; set; }
        public string? PBTypeName { get; set; }
        public string? PBDesc { get; set; }
        public string? PigeonSlotNumber { get; set; }
        public DateTime? PBReturnDate { get; set; }
    }
    public class PersonalBelongingSearch_Request : BaseSearchEntity
    {
        [DefaultValue(null)]
        public DateTime? FromDate { get; set; }

        [DefaultValue(null)]
        public DateTime? ToDate { get; set; }
    }
}
