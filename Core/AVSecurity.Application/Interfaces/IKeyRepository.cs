using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IKeyRepository
    {
        Task<int> SaveKey(Key_Request parameters);

        Task<IEnumerable<Key_Response>> GetKeyList(KeySearch_Request parameters);

        Task<Key_Response?> GetKeyById(int Id);
    }
}
