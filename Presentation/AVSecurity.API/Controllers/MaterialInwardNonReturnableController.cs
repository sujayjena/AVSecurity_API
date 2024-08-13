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
    public class MaterialInwardNonReturnableController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IMaterialInwardNonReturnableRepository _materialInwardNonReturnableRepository;
        private IFileManager _fileManager;

        public MaterialInwardNonReturnableController(IMaterialInwardNonReturnableRepository materialInwardNonReturnableRepository, IFileManager fileManager)
        {
            _materialInwardNonReturnableRepository = materialInwardNonReturnableRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveMaterialInwardNonReturnable(MaterialInwardNonReturnable_Request parameters)
        {
            int result = await _materialInwardNonReturnableRepository.SaveMaterialInwardNonReturnable(parameters);

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

                    var vMaterialInwardNonReturnableChallanObj = new MaterialInwardNonReturnableChallan_Request()
                    {
                        Id = items.Id,
                        MaterialInwardNonReturnableId = result,
                        ChallanNumber = items.ChallanNumber,
                        ChallanImage = items.ChallanImage,
                        ChallanOriginalFileName = items.ChallanOriginalFileName
                    };

                    int resultvPIIssued = await _materialInwardNonReturnableRepository.SaveMaterialInwardNonReturnableChallan(vMaterialInwardNonReturnableChallanObj);
                }
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMaterialInwardNonReturnableList(MaterialInwardNonReturnableSearch_Request parameters)
        {
            IEnumerable<MaterialInwardNonReturnable_Response> lstRoles = await _materialInwardNonReturnableRepository.GetMaterialInwardNonReturnableList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMaterialInwardNonReturnableById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _materialInwardNonReturnableRepository.GetMaterialInwardNonReturnableById(Id);
                if (vResultObj != null)
                {
                    var vMaterialInwardNonReturnableChallanSearch_Request = new MaterialInwardNonReturnableChallanSearch_Request()
                    {
                        MaterialInwardNonReturnableId = vResultObj.Id,
                    };

                    var lstMaterialInwardNonReturnableChallan = await _materialInwardNonReturnableRepository.GetMaterialInwardNonReturnableChallanList(vMaterialInwardNonReturnableChallanSearch_Request);
                    vResultObj.challanList = lstMaterialInwardNonReturnableChallan.ToList();
                }
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
