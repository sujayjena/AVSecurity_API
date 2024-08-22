using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IPAChecklistRepository
    {
        Task<int> SavePAChecklist(PAChecklist_Request parameters);

        Task<IEnumerable<PAChecklist_Response>> GetPAChecklistList(PAChecklistSearch_Request parameters);

        Task<PAChecklist_Response?> GetPAChecklistById(int Id);
    }
}
