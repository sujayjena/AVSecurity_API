using AVSecurity.Application.Enums;
using AVSecurity.Application.Interfaces;
using AVSecurity.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVSecurity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftLogController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IShiftLogRepository _shiftLogRepository;

        public ShiftLogController(IShiftLogRepository shiftLogRepository)
        {
            _shiftLogRepository = shiftLogRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveShiftLog(ShiftLog_Request parameters)
        {
            int result = await _shiftLogRepository.SaveShiftLog(parameters);

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
        public async Task<ResponseModel> GetShiftLogList(ShiftLogSearch_Request parameters)
        {
            IEnumerable<ShiftLog_Response> lstRoles = await _shiftLogRepository.GetShiftLogList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetShiftLogById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _shiftLogRepository.GetShiftLogById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
