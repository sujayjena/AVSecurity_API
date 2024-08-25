using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IVehicleEntryChecklistRepository
    {
        Task<int> SaveVehicleEntryChecklist(VehicleEntryChecklist_Request parameters);

        Task<IEnumerable<VehicleEntryChecklist_Response>> GetVehicleEntryChecklistList(VehicleEntryChecklistSearch_Request parameters);

        Task<VehicleEntryChecklist_Response?> GetVehicleEntryChecklistById(int Id);
    }
}
