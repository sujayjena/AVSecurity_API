using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IPersonalBelongingRepository
    {
        Task<int> SavePersonalBelonging(PersonalBelonging_Request parameters);

        Task<IEnumerable<PersonalBelonging_Response>> GetPersonalBelongingList(PersonalBelongingSearch_Request parameters);

        Task<PersonalBelonging_Response?> GetPersonalBelongingById(int Id);
    }
}
