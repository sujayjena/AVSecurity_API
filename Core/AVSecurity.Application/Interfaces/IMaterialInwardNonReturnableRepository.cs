using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IMaterialInwardNonReturnableRepository
    {
        #region Material Inward Non Returnanble
        Task<int> SaveMaterialInwardNonReturnable(MaterialInwardNonReturnable_Request parameters);

        Task<IEnumerable<MaterialInwardNonReturnable_Response>> GetMaterialInwardNonReturnableList(MaterialInwardNonReturnableSearch_Request parameters);

        Task<MaterialInwardNonReturnable_Response?> GetMaterialInwardNonReturnableById(int Id);
        #endregion

        #region Material Inward Non Returnanble Challan
        Task<int> SaveMaterialInwardNonReturnableChallan(MaterialInwardNonReturnableChallan_Request parameters);
        Task<IEnumerable<MaterialInwardNonReturnableChallan_Response>> GetMaterialInwardNonReturnableChallanList(MaterialInwardNonReturnableChallanSearch_Request parameters);
        #endregion
    }
}
