﻿using AVSecurity.Application.Enums;
using AVSecurity.Application.Interfaces;
using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVSecurity.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMasterController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IAdminMasterRepository _adminMasterRepository;

        public AdminMasterController(IAdminMasterRepository AdminMasterRepository)
        {
            _adminMasterRepository = AdminMasterRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        #region Location

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveLocation(Location_Request parameters)
        {
            int result = await _adminMasterRepository.SaveLocation(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLocationList(Location_Search parameters)
        {
            IEnumerable<Location_Response> lstRoles = await _adminMasterRepository.GetLocationList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetLocationById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetLocationById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Building

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveBuilding(Building_Request parameters)
        {
            int result = await _adminMasterRepository.SaveBuilding(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetBuildingList(Building_Search parameters)
        {
            IEnumerable<Building_Response> lstRoles = await _adminMasterRepository.GetBuildingList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetBuildingById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetBuildingById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Floor

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveFloor(Floor_Request parameters)
        {
            int result = await _adminMasterRepository.SaveFloor(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetFloorList(Floor_Search parameters)
        {
            IEnumerable<Floor_Response> lstRoles = await _adminMasterRepository.GetFloorList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetFloorById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetFloorById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region ReasonType

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveReasonType(ReasonType_Request parameters)
        {
            int result = await _adminMasterRepository.SaveReasonType(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetReasonTypeList(ReasonType_Search parameters)
        {
            IEnumerable<ReasonType_Response> lstRoles = await _adminMasterRepository.GetReasonTypeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetReasonTypeById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetReasonTypeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region VisitorType

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveVisitorType(VisitorType_Request parameters)
        {
            int result = await _adminMasterRepository.SaveVisitorType(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetVisitorTypeList(VisitorType_Search parameters)
        {
            IEnumerable<VisitorType_Response> lstRoles = await _adminMasterRepository.GetVisitorTypeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetVisitorTypeById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetVisitorTypeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region DvmServer

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveDvmServer(DvmServer_Request parameters)
        {
            int result = await _adminMasterRepository.SaveDvmServer(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetDvmServerList(DvmServer_Search parameters)
        {
            IEnumerable<DvmServer_Response> lstRoles = await _adminMasterRepository.GetDvmServerList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetDvmServerById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetDvmServerById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region EbiServer

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveEbiServer(EbiServer_Request parameters)
        {
            int result = await _adminMasterRepository.SaveEbiServer(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEbiServerList(EbiServer_Search parameters)
        {
            IEnumerable<EbiServer_Response> lstRoles = await _adminMasterRepository.GetEbiServerList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEbiServerById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetEbiServerById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region EmergencyType

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveEmergencyType(EmergencyType_Request parameters)
        {
            int result = await _adminMasterRepository.SaveEmergencyType(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEmergencyTypeList(EmergencyType_Search parameters)
        {
            IEnumerable<EmergencyType_Response> lstRoles = await _adminMasterRepository.GetEmergencyTypeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEmergencyTypeById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetEmergencyTypeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region EmergencyClosure

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveEmergencyClosure(EmergencyClosure_Request parameters)
        {
            int result = await _adminMasterRepository.SaveEmergencyClosure(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEmergencyClosureList(EmergencyClosure_Search parameters)
        {
            IEnumerable<EmergencyClosure_Response> lstRoles = await _adminMasterRepository.GetEmergencyClosureList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEmergencyClosureById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetEmergencyClosureById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Shift

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveShift(Shift_Request parameters)
        {
            int result = await _adminMasterRepository.SaveShift(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetShiftList(Shift_Search parameters)
        {
            IEnumerable<Shift_Response> lstRoles = await _adminMasterRepository.GetShiftList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetShiftById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetShiftById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Route

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveRoute(Route_Request parameters)
        {
            int result = await _adminMasterRepository.SaveRoute(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetRouteList(Route_Search parameters)
        {
            IEnumerable<Route_Response> lstRoles = await _adminMasterRepository.GetRouteList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetRouteById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetRouteById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Verified

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveVerified(Verified_Request parameters)
        {
            int result = await _adminMasterRepository.SaveVerified(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetVerifiedList(Verified_Search parameters)
        {
            IEnumerable<Verified_Response> lstRoles = await _adminMasterRepository.GetVerifiedList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetVerifiedById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetVerifiedById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region MeritalStatus

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveMeritalStatus(MeritalStatus_Request parameters)
        {
            int result = await _adminMasterRepository.SaveMeritalStatus(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMeritalStatusList(MeritalStatus_Search parameters)
        {
            IEnumerable<MeritalStatus_Response> lstRoles = await _adminMasterRepository.GetMeritalStatusList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMeritalStatusById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetMeritalStatusById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region EmployeeType

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveEmployeeType(EmployeeType_Request parameters)
        {
            int result = await _adminMasterRepository.SaveEmployeeType(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEmployeeTypeList(EmployeeType_Search parameters)
        {
            IEnumerable<EmployeeType_Response> lstRoles = await _adminMasterRepository.GetEmployeeTypeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEmployeeTypeById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetEmployeeTypeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Gender

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveGender(Gender_Request parameters)
        {
            int result = await _adminMasterRepository.SaveGender(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetGenderList(Gender_Search parameters)
        {
            IEnumerable<Gender_Response> lstRoles = await _adminMasterRepository.GetGenderList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetGenderById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetGenderById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region EventType

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveEventType(EventType_Request parameters)
        {
            int result = await _adminMasterRepository.SaveEventType(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEventTypeList(EventType_Search parameters)
        {
            IEnumerable<EventType_Response> lstRoles = await _adminMasterRepository.GetEventTypeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEventTypeById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetEventTypeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region CourierName

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveCourierName(CourierName_Request parameters)
        {
            int result = await _adminMasterRepository.SaveCourierName(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetCourierNameList(CourierName_Search parameters)
        {
            IEnumerable<CourierName_Response> lstRoles = await _adminMasterRepository.GetCourierNameList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetCourierNameById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetCourierNameById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region PBType

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SavePBType(PBType_Request parameters)
        {
            int result = await _adminMasterRepository.SavePBType(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetPBTypeList(PBType_Search parameters)
        {
            IEnumerable<PBType_Response> lstRoles = await _adminMasterRepository.GetPBTypeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetPBTypeById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetPBTypeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region IncidentType

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveIncidentType(IncidentType_Request parameters)
        {
            int result = await _adminMasterRepository.SaveIncidentType(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetIncidentTypeList(IncidentType_Search parameters)
        {
            IEnumerable<IncidentType_Response> lstRoles = await _adminMasterRepository.GetIncidentTypeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetIncidentTypeById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetIncidentTypeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region HandedOverByName

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveHandedOverByName(HandedOverByName_Request parameters)
        {
            int result = await _adminMasterRepository.SaveHandedOverByName(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetHandedOverByNameList(HandedOverByName_Search parameters)
        {
            IEnumerable<HandedOverByName_Response> lstRoles = await _adminMasterRepository.GetHandedOverByNameList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetHandedOverByNameById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetHandedOverByNameById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region VehicleType

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveVehicleType(VehicleType_Request parameters)
        {
            int result = await _adminMasterRepository.SaveVehicleType(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetVehicleTypeList(VehicleType_Search parameters)
        {
            IEnumerable<VehicleType_Response> lstRoles = await _adminMasterRepository.GetVehicleTypeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetVehicleTypeById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetVehicleTypeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region VisitPurpose

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveVisitPurpose(VisitPurpose_Request parameters)
        {
            int result = await _adminMasterRepository.SaveVisitPurpose(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetVisitPurposeList(VisitPurpose_Search parameters)
        {
            IEnumerable<VisitPurpose_Response> lstRoles = await _adminMasterRepository.GetVisitPurposeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetVisitPurposeById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetVisitPurposeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

        #region Material Status

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveMaterialStatus(MaterialStatus_Request parameters)
        {
            int result = await _adminMasterRepository.SaveMaterialStatus(parameters);

            if (result == (int)SaveOperationEnums.NoRecordExists)
            {
                _response.Message = "No record exists";
            }
            else if (result == (int)SaveOperationEnums.ReocrdExists)
            {
                _response.Message = "Record is already exists";
            }
            else if (result == (int)SaveOperationEnums.NoResult)
            {
                _response.Message = "Something went wrong, please try again";
            }
            else
            {
                _response.Message = "Record details saved sucessfully";
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMaterialStatusList(MaterialStatus_Search parameters)
        {
            IEnumerable<MaterialStatus_Response> lstRoles = await _adminMasterRepository.GetMaterialStatusList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMaterialStatusById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _adminMasterRepository.GetMaterialStatusById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion

    }
}
