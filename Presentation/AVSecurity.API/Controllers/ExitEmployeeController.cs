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
    public class ExitEmployeeController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IExitEmployeeRepository _exitEmployeeRepository;

        public ExitEmployeeController(IExitEmployeeRepository exitEmployeeRepository)
        {
            _exitEmployeeRepository = exitEmployeeRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveExitEmployee(ExitEmployee_Request parameters)
        {
            int result = await _exitEmployeeRepository.SaveExitEmployee(parameters);

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
        public async Task<ResponseModel> GetExitEmployeeList(ExitEmployeeSearch_Request parameters)
        {
            IEnumerable<ExitEmployee_Response> lstRoles = await _exitEmployeeRepository.GetExitEmployeeList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetExitEmployeeById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _exitEmployeeRepository.GetExitEmployeeById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
