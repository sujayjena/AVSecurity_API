using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IAdminMasterRepository
    {
        #region Location

        Task<int> SaveLocation(Location_Request parameters);

        Task<IEnumerable<Location_Response>> GetLocationList(Location_Search parameters);

        Task<Location_Response?> GetLocationById(int Id);

        #endregion

        #region Building

        Task<int> SaveBuilding(Building_Request parameters);

        Task<IEnumerable<Building_Response>> GetBuildingList(Building_Search parameters);

        Task<Building_Response?> GetBuildingById(int Id);

        #endregion

        #region Floor

        Task<int> SaveFloor(Floor_Request parameters);

        Task<IEnumerable<Floor_Response>> GetFloorList(Floor_Search parameters);

        Task<Floor_Response?> GetFloorById(int Id);

        #endregion

        #region ReasonType

        Task<int> SaveReasonType(ReasonType_Request parameters);

        Task<IEnumerable<ReasonType_Response>> GetReasonTypeList(ReasonType_Search parameters);

        Task<ReasonType_Response?> GetReasonTypeById(int Id);

        #endregion

        #region VisitorType

        Task<int> SaveVisitorType(VisitorType_Request parameters);

        Task<IEnumerable<VisitorType_Response>> GetVisitorTypeList(VisitorType_Search parameters);

        Task<VisitorType_Response?> GetVisitorTypeById(int Id);

        #endregion
    }
}
