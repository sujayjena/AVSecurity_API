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
    public class MasterAccessCardController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IMasterAccessCardRepository _masterAccessCardRepository;

        public MasterAccessCardController(IMasterAccessCardRepository masterAccessCardRepository)
        {
            _masterAccessCardRepository = masterAccessCardRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveMasterAccessCard(MasterAccessCard_Request parameters)
        {
            int result = await _masterAccessCardRepository.SaveMasterAccessCard(parameters);

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
        public async Task<ResponseModel> GetMasterAccessCardList(MasterAccessCardSearch_Request parameters)
        {
            IEnumerable<MasterAccessCard_Response> lstRoles = await _masterAccessCardRepository.GetMasterAccessCardList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMasterAccessCardById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _masterAccessCardRepository.GetMasterAccessCardById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
