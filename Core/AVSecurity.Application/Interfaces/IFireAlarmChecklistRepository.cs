using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IFireAlarmChecklistRepository
    {
        Task<int> SaveFireAlarmChecklist(FireAlarmChecklist_Request parameters);

        Task<IEnumerable<FireAlarmChecklist_Response>> GetFireAlarmChecklistList(FireAlarmChecklistSearch_Request parameters);

        Task<FireAlarmChecklist_Response?> GetFireAlarmChecklistById(int Id);
    }
}
