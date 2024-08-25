using AVSecurity.Application.Enums;
using AVSecurity.Application.Interfaces;
using AVSecurity.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVSecurity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalBelongingController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IPersonalBelongingRepository _personalBelongingRepository;

        public PersonalBelongingController(IPersonalBelongingRepository personalBelongingRepository)
        {
            _personalBelongingRepository = personalBelongingRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SavePersonalBelonging(PersonalBelonging_Request parameters)
        {
            int result = await _personalBelongingRepository.SavePersonalBelonging(parameters);

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
        public async Task<ResponseModel> GetPersonalBelongingList(PersonalBelongingSearch_Request parameters)
        {
            IEnumerable<PersonalBelonging_Response> lstRoles = await _personalBelongingRepository.GetPersonalBelongingList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetPersonalBelongingById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _personalBelongingRepository.GetPersonalBelongingById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
