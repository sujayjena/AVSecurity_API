using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface ICommandCentreRepository
    {
        Task<int> SaveCommandCentre(CommandCentre_Request parameters);

        Task<IEnumerable<CommandCentre_Response>> GetCommandCentreList(BaseSearchEntity parameters);

        Task<CommandCentre_Response?> GetCommandCentreById(int Id);
    }
}
