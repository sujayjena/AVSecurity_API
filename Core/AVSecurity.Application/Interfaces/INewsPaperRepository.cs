using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface INewsPaperRepository
    {
        Task<int> SaveNewsPaper(NewsPaper_Request parameters);

        Task<IEnumerable<NewsPaper_Response>> GetNewsPaperList(NewsPaperSearch_Request parameters);

        Task<NewsPaper_Response?> GetNewsPaperById(int Id);
    }
}
