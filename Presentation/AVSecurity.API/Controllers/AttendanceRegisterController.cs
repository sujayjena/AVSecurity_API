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
    public class AttendanceRegisterController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IAttendanceRegisterRepository _attendanceRegisterRepository;

        public AttendanceRegisterController(IAttendanceRegisterRepository attendanceRegisterRepository)
        {
            _attendanceRegisterRepository = attendanceRegisterRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        #region Location

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveAttendanceRegister(AttendanceRegister_Request parameters)
        {
            int result = await _attendanceRegisterRepository.SaveAttendanceRegister(parameters);

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
        public async Task<ResponseModel> GetAttendanceRegisterList(BaseSearchEntity parameters)
        {
            IEnumerable<AttendanceRegister_Response> lstRoles = await _attendanceRegisterRepository.GetAttendanceRegisterList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetAttendanceRegisterById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _attendanceRegisterRepository.GetAttendanceRegisterById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        #endregion
    }
}
