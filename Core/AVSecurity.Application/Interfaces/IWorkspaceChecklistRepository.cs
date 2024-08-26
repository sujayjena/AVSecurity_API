using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IWorkspaceChecklistRepository
    {
        Task<int> SaveWorkspaceChecklist(WorkspaceChecklist_Request parameters);

        Task<IEnumerable<WorkspaceChecklist_Response>> GetWorkspaceChecklistList(WorkspaceChecklistSearch_Request parameters);

        Task<WorkspaceChecklist_Response?> GetWorkspaceChecklistById(int Id);
    }
}
