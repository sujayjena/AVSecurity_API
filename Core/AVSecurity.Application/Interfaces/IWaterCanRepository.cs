using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IWaterCanRepository
    {
        Task<int> SaveWaterCan(WaterCan_Request parameters);

        Task<IEnumerable<WaterCan_Response>> GetWaterCanList(WaterCanSearch_Request parameters);

        Task<WaterCan_Response?> GetWaterCanById(int Id);
    }
}
