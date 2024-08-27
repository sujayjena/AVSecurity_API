using AVSecurity.Application.Enums;
using AVSecurity.Application.Interfaces;
using AVSecurity.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVSecurity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomingCourierController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IIncomingCourierRepository _incomingCourierRepository;

        public IncomingCourierController(IIncomingCourierRepository incomingCourierRepository)
        {
            _incomingCourierRepository = incomingCourierRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveIncomingCourier(IncomingCourier_Request parameters)
        {
            int result = await _incomingCourierRepository.SaveIncomingCourier(parameters);

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
        public async Task<ResponseModel> GetIncomingCourierList(IncomingCourierSearch_Request parameters)
        {
            IEnumerable<IncomingCourier_Response> lstRoles = await _incomingCourierRepository.GetIncomingCourierList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetIncomingCourierById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _incomingCourierRepository.GetIncomingCourierById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
