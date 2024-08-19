using AVSecurity.Application.Enums;
using AVSecurity.Application.Interfaces;
using AVSecurity.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVSecurity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutgoingCourierController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IOutgoingCourierRepository _outgoingCourierRepository;

        public OutgoingCourierController(IOutgoingCourierRepository outgoingCourierRepository)
        {
            _outgoingCourierRepository = outgoingCourierRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveOutgoingCourier(OutgoingCourier_Request parameters)
        {
            int result = await _outgoingCourierRepository.SaveOutgoingCourier(parameters);

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
        public async Task<ResponseModel> GetOutgoingCourierList(OutgoingCourierSearch_Request parameters)
        {
            IEnumerable<OutgoingCourier_Response> lstRoles = await _outgoingCourierRepository.GetOutgoingCourierList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOutgoingCourierById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _outgoingCourierRepository.GetOutgoingCourierById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
