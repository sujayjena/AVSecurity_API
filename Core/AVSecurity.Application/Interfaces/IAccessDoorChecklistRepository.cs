using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IAccessDoorChecklistRepository
    {
        Task<int> SaveAccessDoorChecklist(AccessDoorChecklist_Request parameters);

        Task<IEnumerable<AccessDoorChecklist_Response>> GetAccessDoorChecklistList(BaseSearchEntity parameters);

        Task<AccessDoorChecklist_Response?> GetAccessDoorChecklistById(int Id);
    }
}
