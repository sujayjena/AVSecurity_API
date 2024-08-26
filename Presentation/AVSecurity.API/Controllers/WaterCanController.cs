using AVSecurity.Application.Enums;
using AVSecurity.Application.Interfaces;
using AVSecurity.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVSecurity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterCanController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IWaterCanRepository _waterCanRepository;

        public WaterCanController(IWaterCanRepository waterCanRepository)
        {
            _waterCanRepository = waterCanRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveWaterCan(WaterCan_Request parameters)
        {
            int result = await _waterCanRepository.SaveWaterCan(parameters);

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
        public async Task<ResponseModel> GetWaterCanList(WaterCanSearch_Request parameters)
        {
            IEnumerable<WaterCan_Response> lstRoles = await _waterCanRepository.GetWaterCanList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetWaterCanById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _waterCanRepository.GetWaterCanById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
