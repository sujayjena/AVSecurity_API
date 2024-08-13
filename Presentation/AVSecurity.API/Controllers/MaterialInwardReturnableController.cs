using AVSecurity.Application.Enums;
using AVSecurity.Application.Helpers;
using AVSecurity.Application.Interfaces;
using AVSecurity.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AVSecurity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialInwardReturnableController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IMaterialInwardReturnableRepository _materialInwardReturnableRepository;
        private IFileManager _fileManager;

        public MaterialInwardReturnableController(IMaterialInwardReturnableRepository materialInwardReturnableRepository, IFileManager fileManager)
        {
            _materialInwardReturnableRepository = materialInwardReturnableRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveMaterialInwardReturnable(MaterialInwardReturnable_Request parameters)
        {
            int result = await _materialInwardReturnableRepository.SaveMaterialInwardReturnable(parameters);

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

                foreach (var items in parameters.challanList)
                {
                    // PO Upload
                    if (parameters! != null && !string.IsNullOrWhiteSpace(items.ChallanImage_Base64))
                    {
                        var vUploadFile = _fileManager.UploadDocumentsBase64ToFile(items.ChallanImage_Base64, "\\Uploads\\Challan\\", items.ChallanOriginalFileName);

                        if (!string.IsNullOrWhiteSpace(vUploadFile))
                        {
                            items.ChallanImage = vUploadFile;
                        }
                    }

                    var vMaterialInwardReturnableChallanObj = new MaterialInwardReturnableChallan_Request()
                    {
                        Id = items.Id,
                        MaterialInwardReturnableId = result,
                        ChallanNumber = items.ChallanNumber,
                        ChallanImage = items.ChallanImage,
                        ChallanOriginalFileName = items.ChallanOriginalFileName
                    };

                    int resultvPIIssued = await _materialInwardReturnableRepository.SaveMaterialInwardReturnableChallan(vMaterialInwardReturnableChallanObj);
                }
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMaterialInwardReturnableList(MaterialInwardReturnableSearch_Request parameters)
        {
            IEnumerable<MaterialInwardReturnable_Response> lstRoles = await _materialInwardReturnableRepository.GetMaterialInwardReturnableList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMaterialInwardReturnableById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _materialInwardReturnableRepository.GetMaterialInwardReturnableById(Id);
                if (vResultObj != null)
                {
                    var vMaterialInwardReturnableChallanSearch_Request = new MaterialInwardReturnableChallanSearch_Request()
                    {
                        MaterialInwardReturnableId = vResultObj.Id,
                    };

                    var lstMaterialInwardReturnableChallan = await _materialInwardReturnableRepository.GetMaterialInwardReturnableChallanList(vMaterialInwardReturnableChallanSearch_Request);
                    vResultObj.challanList = lstMaterialInwardReturnableChallan.ToList();
                }
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
