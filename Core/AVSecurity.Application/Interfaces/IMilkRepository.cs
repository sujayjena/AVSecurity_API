using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IMilkRepository
    {
        Task<int> SaveMilk(Milk_Request parameters);

        Task<IEnumerable<Milk_Response>> GetMilkList(MilkSearch_Request parameters);

        Task<Milk_Response?> GetMilkById(int Id);
    }
}
