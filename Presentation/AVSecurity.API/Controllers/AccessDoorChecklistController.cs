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
    public class AccessDoorChecklistController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IAccessDoorChecklistRepository _accessDoorChecklistRepository;

        public AccessDoorChecklistController(IAccessDoorChecklistRepository accessDoorChecklistRepository)
        {
            _accessDoorChecklistRepository = accessDoorChecklistRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveAccessDoorChecklist(AccessDoorChecklist_Request parameters)
        {
            int result = await _accessDoorChecklistRepository.SaveAccessDoorChecklist(parameters);

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
        public async Task<ResponseModel> GetAccessDoorChecklistList(AccessDoorChecklistSearch_Request parameters)
        {
            IEnumerable<AccessDoorChecklist_Response> lstRoles = await _accessDoorChecklistRepository.GetAccessDoorChecklistList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetAccessDoorChecklistById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _accessDoorChecklistRepository.GetAccessDoorChecklistById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
