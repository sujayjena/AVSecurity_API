using AVSecurity.Application.Enums;
using AVSecurity.Application.Interfaces;
using AVSecurity.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVSecurity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccurenceController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IOccurenceRepository _occurenceRepository;

        public OccurenceController(IOccurenceRepository occurenceRepository)
        {
            _occurenceRepository = occurenceRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveOccurence(Occurence_Request parameters)
        {
            int result = await _occurenceRepository.SaveOccurence(parameters);

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
        public async Task<ResponseModel> GetOccurenceList(OccurenceSearch_Request parameters)
        {
            IEnumerable<Occurence_Response> lstRoles = await _occurenceRepository.GetOccurenceList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetOccurenceById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _occurenceRepository.GetOccurenceById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
