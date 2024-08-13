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
    public class FireAlarmChecklistController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IFireAlarmChecklistRepository _fireAlarmChecklistRepository;

        public FireAlarmChecklistController(IFireAlarmChecklistRepository fireAlarmChecklistRepository)
        {
            _fireAlarmChecklistRepository = fireAlarmChecklistRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveFireAlarmChecklist(FireAlarmChecklist_Request parameters)
        {
            int result = await _fireAlarmChecklistRepository.SaveFireAlarmChecklist(parameters);

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
        public async Task<ResponseModel> GetFireAlarmChecklistList(FireAlarmChecklistSearch_Request parameters)
        {
            IEnumerable<FireAlarmChecklist_Response> lstRoles = await _fireAlarmChecklistRepository.GetFireAlarmChecklistList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetFireAlarmChecklistById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _fireAlarmChecklistRepository.GetFireAlarmChecklistById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
