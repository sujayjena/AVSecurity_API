using AVSecurity.Application.Enums;
using AVSecurity.Application.Interfaces;
using AVSecurity.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVSecurity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityIncidentController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly ISecurityIncidentRepository _securityIncidentRepository;

        public SecurityIncidentController(ISecurityIncidentRepository securityIncidentRepository)
        {
            _securityIncidentRepository = securityIncidentRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveSecurityIncident(SecurityIncident_Request parameters)
        {
            int result = await _securityIncidentRepository.SaveSecurityIncident(parameters);

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
        public async Task<ResponseModel> GetSecurityIncidentList(SecurityIncidentSearch_Request parameters)
        {
            IEnumerable<SecurityIncident_Response> lstRoles = await _securityIncidentRepository.GetSecurityIncidentList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetSecurityIncidentById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _securityIncidentRepository.GetSecurityIncidentById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
