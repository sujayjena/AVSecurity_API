using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IOccurenceRepository
    {
        Task<int> SaveOccurence(Occurence_Request parameters);

        Task<IEnumerable<Occurence_Response>> GetOccurenceList(OccurenceSearch_Request parameters);

        Task<Occurence_Response?> GetOccurenceById(int Id);
    }
}
