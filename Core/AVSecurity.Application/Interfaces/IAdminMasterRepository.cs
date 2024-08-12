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

        #region DvmServer

        Task<int> SaveDvmServer(DvmServer_Request parameters);

        Task<IEnumerable<DvmServer_Response>> GetDvmServerList(DvmServer_Search parameters);

        Task<DvmServer_Response?> GetDvmServerById(int Id);

        #endregion

        #region EbiServer

        Task<int> SaveEbiServer(EbiServer_Request parameters);

        Task<IEnumerable<EbiServer_Response>> GetEbiServerList(EbiServer_Search parameters);

        Task<EbiServer_Response?> GetEbiServerById(int Id);

        #endregion

        #region EmergencyType

        Task<int> SaveEmergencyType(EmergencyType_Request parameters);

        Task<IEnumerable<EmergencyType_Response>> GetEmergencyTypeList(EmergencyType_Search parameters);

        Task<EmergencyType_Response?> GetEmergencyTypeById(int Id);

        #endregion

        #region EmergencyClosure

        Task<int> SaveEmergencyClosure(EmergencyClosure_Request parameters);

        Task<IEnumerable<EmergencyClosure_Response>> GetEmergencyClosureList(EmergencyClosure_Search parameters);

        Task<EmergencyClosure_Response?> GetEmergencyClosureById(int Id);

        #endregion

        #region Shift

        Task<int> SaveShift(Shift_Request parameters);

        Task<IEnumerable<Shift_Response>> GetShiftList(Shift_Search parameters);

        Task<Shift_Response?> GetShiftById(int Id);

        #endregion

        #region Route

        Task<int> SaveRoute(Route_Request parameters);

        Task<IEnumerable<Route_Response>> GetRouteList(Route_Search parameters);

        Task<Route_Response?> GetRouteById(int Id);

        #endregion

        #region Verified

        Task<int> SaveVerified(Verified_Request parameters);

        Task<IEnumerable<Verified_Response>> GetVerifiedList(Verified_Search parameters);

        Task<Verified_Response?> GetVerifiedById(int Id);

        #endregion

        #region MeritalStatus

        Task<int> SaveMeritalStatus(MeritalStatus_Request parameters);

        Task<IEnumerable<MeritalStatus_Response>> GetMeritalStatusList(MeritalStatus_Search parameters);

        Task<MeritalStatus_Response?> GetMeritalStatusById(int Id);

        #endregion

        #region EmployeeType

        Task<int> SaveEmployeeType(EmployeeType_Request parameters);

        Task<IEnumerable<EmployeeType_Response>> GetEmployeeTypeList(EmployeeType_Search parameters);

        Task<EmployeeType_Response?> GetEmployeeTypeById(int Id);

        #endregion

        #region Gender

        Task<int> SaveGender(Gender_Request parameters);

        Task<IEnumerable<Gender_Response>> GetGenderList(Gender_Search parameters);

        Task<Gender_Response?> GetGenderById(int Id);

        #endregion

        #region EventType

        Task<int> SaveEventType(EventType_Request parameters);

        Task<IEnumerable<EventType_Response>> GetEventTypeList(EventType_Search parameters);

        Task<EventType_Response?> GetEventTypeById(int Id);

        #endregion

        #region CourierName

        Task<int> SaveCourierName(CourierName_Request parameters);

        Task<IEnumerable<CourierName_Response>> GetCourierNameList(CourierName_Search parameters);

        Task<CourierName_Response?> GetCourierNameById(int Id);

        #endregion

        #region PBType

        Task<int> SavePBType(PBType_Request parameters);

        Task<IEnumerable<PBType_Response>> GetPBTypeList(PBType_Search parameters);

        Task<PBType_Response?> GetPBTypeById(int Id);

        #endregion

        #region IncidentType

        Task<int> SaveIncidentType(IncidentType_Request parameters);

        Task<IEnumerable<IncidentType_Response>> GetIncidentTypeList(IncidentType_Search parameters);

        Task<IncidentType_Response?> GetIncidentTypeById(int Id);

        #endregion

        #region HandedOverByName

        Task<int> SaveHandedOverByName(HandedOverByName_Request parameters);

        Task<IEnumerable<HandedOverByName_Response>> GetHandedOverByNameList(HandedOverByName_Search parameters);

        Task<HandedOverByName_Response?> GetHandedOverByNameById(int Id);

        #endregion

        #region VehicleType

        Task<int> SaveVehicleType(VehicleType_Request parameters);

        Task<IEnumerable<VehicleType_Response>> GetVehicleTypeList(VehicleType_Search parameters);

        Task<VehicleType_Response?> GetVehicleTypeById(int Id);

        #endregion

        #region VisitPurpose

        Task<int> SaveVisitPurpose(VisitPurpose_Request parameters);

        Task<IEnumerable<VisitPurpose_Response>> GetVisitPurposeList(VisitPurpose_Search parameters);

        Task<VisitPurpose_Response?> GetVisitPurposeById(int Id);

        #endregion

        #region Material Status

        Task<int> SaveMaterialStatus(MaterialStatus_Request parameters);

        Task<IEnumerable<MaterialStatus_Response>> GetMaterialStatusList(MaterialStatus_Search parameters);

        Task<MaterialStatus_Response?> GetMaterialStatusById(int Id);

        #endregion
    }
}
