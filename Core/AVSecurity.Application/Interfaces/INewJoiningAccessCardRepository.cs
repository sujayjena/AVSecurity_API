using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface INewJoiningAccessCardRepository
    {
        Task<int> SaveNewJoiningAccessCard(NewJoiningAccessCard_Request parameters);

        Task<IEnumerable<NewJoiningAccessCard_Response>> GetNewJoiningAccessCardList(NewJoiningAccessCardSearch_Request parameters);

        Task<NewJoiningAccessCard_Response?> GetNewJoiningAccessCardById(int Id);
    }
}
