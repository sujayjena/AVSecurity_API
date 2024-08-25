using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IShiftLogRepository
    {
        Task<int> SaveShiftLog(ShiftLog_Request parameters);

        Task<IEnumerable<ShiftLog_Response>> GetShiftLogList(ShiftLogSearch_Request parameters);

        Task<ShiftLog_Response?> GetShiftLogById(int Id);
    }
}
