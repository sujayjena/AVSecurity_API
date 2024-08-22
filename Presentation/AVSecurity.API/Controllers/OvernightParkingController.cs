using AVSecurity.Application.Enums;
using AVSecurity.Application.Interfaces;
using AVSecurity.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVSecurity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OvernightParkingController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IOvernightParkingRepository _overnightParkingRepository;

        public OvernightParkingController(IOvernightParkingRepository overnightParkingRepository)
        {
            _overnightParkingRepository = overnightParkingRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveOvernightParking(OvernightParking_Request parameters)
        {
            int result = await _overnightParkingRepository.SaveOvernightParking(parameters);

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
        public async Task<ResponseModel> GetOvernightParkingList(OvernightParkingSearch_Request parameters)
        {
            IEnumerable<OvernightParking_Response> lstRoles = await _overnightParkingRepository.GetOvernightParkingList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOvernightParkingById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _overnightParkingRepository.GetOvernightParkingById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}

