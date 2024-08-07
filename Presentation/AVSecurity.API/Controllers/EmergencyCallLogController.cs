using AVSecurity.Application.Enums;
using AVSecurity.Application.Interfaces;
using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVSecurity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyCallLogController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IEmergencyCallLogRepository _emergencyCallLogRepository;

        public EmergencyCallLogController(IEmergencyCallLogRepository emergencyCallLogRepository)
        {
            _emergencyCallLogRepository = emergencyCallLogRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveEmergencyCallLog(EmergencyCallLog_Request parameters)
        {
            int result = await _emergencyCallLogRepository.SaveEmergencyCallLog(parameters);

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
        public async Task<ResponseModel> GetEmergencyCallLogList(BaseSearchEntity parameters)
        {
            IEnumerable<EmergencyCallLog_Response> lstRoles = await _emergencyCallLogRepository.GetEmergencyCallLogList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetEmergencyCallLogById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _emergencyCallLogRepository.GetEmergencyCallLogById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
