using AVSecurity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Models
{
    public class CommandCentreModel
    {
    }
    public class CommandCentre_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? EntryBy { get; set; }
        public string? Reason { get; set; }
        public string? ActionToken { get; set; }
        public DateTime? ExitDate { get; set; }
        public string? Remarks { get; set; }
    }

    public class CommandCentre_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? EntryBy { get; set; }
        public string? Reason { get; set; }
        public string? ActionToken { get; set; }
        public DateTime? ExitDate { get; set; }
        public string? Remarks { get; set; }
    }
}
