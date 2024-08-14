using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IMaterialOutwardReturnableRepository
    {
        #region Material Outward  Returnanble
        Task<int> SaveMaterialOutwardReturnable(MaterialOutwardReturnable_Request parameters);

        Task<IEnumerable<MaterialOutwardReturnable_Response>> GetMaterialOutwardReturnableList(MaterialOutwardReturnableSearch_Request parameters);

        Task<MaterialOutwardReturnable_Response?> GetMaterialOutwardReturnableById(int Id);
        #endregion

        #region Material Outward  Returnanble Challan
        Task<int> SaveMaterialOutwardReturnableChallan(MaterialOutwardReturnableChallan_Request parameters);
        Task<IEnumerable<MaterialOutwardReturnableChallan_Response>> GetMaterialOutwardReturnableChallanList(MaterialOutwardReturnableChallanSearch_Request parameters);
        #endregion
    }
}
