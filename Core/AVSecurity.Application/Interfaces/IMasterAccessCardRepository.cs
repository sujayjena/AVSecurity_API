using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IMasterAccessCardRepository
    {
        Task<int> SaveMasterAccessCard(MasterAccessCard_Request parameters);

        Task<IEnumerable<MasterAccessCard_Response>> GetMasterAccessCardList(BaseSearchEntity parameters);

        Task<MasterAccessCard_Response?> GetMasterAccessCardById(int Id);
    }
}
