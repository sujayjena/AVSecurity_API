using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface ISecurityIncidentRepository
    {
        Task<int> SaveSecurityIncident(SecurityIncident_Request parameters);

        Task<IEnumerable<SecurityIncident_Response>> GetSecurityIncidentList(SecurityIncidentSearch_Request parameters);

        Task<SecurityIncident_Response?> GetSecurityIncidentById(int Id);
    }
}
