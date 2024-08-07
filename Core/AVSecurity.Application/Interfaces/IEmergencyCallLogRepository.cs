using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IEmergencyCallLogRepository
    {
        Task<int> SaveEmergencyCallLog(EmergencyCallLog_Request parameters);

        Task<IEnumerable<EmergencyCallLog_Response>> GetEmergencyCallLogList(BaseSearchEntity parameters);

        Task<EmergencyCallLog_Response?> GetEmergencyCallLogById(int Id);
    }
}
