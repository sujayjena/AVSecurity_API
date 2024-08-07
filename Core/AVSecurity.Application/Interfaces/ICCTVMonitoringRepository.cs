using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface ICCTVMonitoringRepository
    {
        Task<int> SaveCCTVMonitoring(CCTVMonitoring_Request parameters);

        Task<IEnumerable<CCTVMonitoring_Response>> GetCCTVMonitoringList(BaseSearchEntity parameters);

        Task<CCTVMonitoring_Response?> GetCCTVMonitoringById(int Id);
    }
}
