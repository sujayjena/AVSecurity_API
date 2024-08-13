using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IMaterialInwardReturnableRepository
    {
        #region Material Inward  Returnanble
        Task<int> SaveMaterialInwardReturnable(MaterialInwardReturnable_Request parameters);

        Task<IEnumerable<MaterialInwardReturnable_Response>> GetMaterialInwardReturnableList(MaterialInwardReturnableSearch_Request parameters);

        Task<MaterialInwardReturnable_Response?> GetMaterialInwardReturnableById(int Id);
        #endregion

        #region Material Inward  Returnanble Challan
        Task<int> SaveMaterialInwardReturnableChallan(MaterialInwardReturnableChallan_Request parameters);
        Task<IEnumerable<MaterialInwardReturnableChallan_Response>> GetMaterialInwardReturnableChallanList(MaterialInwardReturnableChallanSearch_Request parameters);
        #endregion
    }
}
