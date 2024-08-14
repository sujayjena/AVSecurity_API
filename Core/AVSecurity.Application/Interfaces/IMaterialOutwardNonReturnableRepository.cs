using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IMaterialOutwardNonReturnableRepository
    {
        #region Material Outward Non Returnanble
        Task<int> SaveMaterialOutwardNonReturnable(MaterialOutwardNonReturnable_Request parameters);

        Task<IEnumerable<MaterialOutwardNonReturnable_Response>> GetMaterialOutwardNonReturnableList(MaterialOutwardNonReturnableSearch_Request parameters);

        Task<MaterialOutwardNonReturnable_Response?> GetMaterialOutwardNonReturnableById(int Id);
        #endregion

        #region Material Outward Non Returnanble Challan
        Task<int> SaveMaterialOutwardNonReturnableChallan(MaterialOutwardNonReturnableChallan_Request parameters);
        Task<IEnumerable<MaterialOutwardNonReturnableChallan_Response>> GetMaterialOutwardNonReturnableChallanList(MaterialOutwardNonReturnableChallanSearch_Request parameters);
        #endregion
    }
}
