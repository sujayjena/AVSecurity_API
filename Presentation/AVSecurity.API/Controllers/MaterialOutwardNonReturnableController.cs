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
    public class MaterialOutwardNonReturnableController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IMaterialOutwardNonReturnableRepository _materialOutwardNonReturnableRepository;
        private IFileManager _fileManager;

        public MaterialOutwardNonReturnableController(IMaterialOutwardNonReturnableRepository materialOutwardNonReturnableRepository, IFileManager fileManager)
        {
            _materialOutwardNonReturnableRepository = materialOutwardNonReturnableRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveMaterialOutwardNonReturnable(MaterialOutwardNonReturnable_Request parameters)
        {
            int result = await _materialOutwardNonReturnableRepository.SaveMaterialOutwardNonReturnable(parameters);

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

                    var vMaterialOutwardNonReturnableChallanObj = new MaterialOutwardNonReturnableChallan_Request()
                    {
                        Id = items.Id,
                        MaterialOutwardNonReturnableId = result,
                        ChallanNumber = items.ChallanNumber,
                        ChallanImage = items.ChallanImage,
                        ChallanOriginalFileName = items.ChallanOriginalFileName
                    };

                    int resultvPIIssued = await _materialOutwardNonReturnableRepository.SaveMaterialOutwardNonReturnableChallan(vMaterialOutwardNonReturnableChallanObj);
                }
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMaterialOutwardNonReturnableList(MaterialOutwardNonReturnableSearch_Request parameters)
        {
            IEnumerable<MaterialOutwardNonReturnable_Response> lstRoles = await _materialOutwardNonReturnableRepository.GetMaterialOutwardNonReturnableList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMaterialOutwardNonReturnableById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _materialOutwardNonReturnableRepository.GetMaterialOutwardNonReturnableById(Id);
                if (vResultObj != null)
                {
                    var vMaterialOutwardNonReturnableChallanSearch_Request = new MaterialOutwardNonReturnableChallanSearch_Request()
                    {
                        MaterialOutwardNonReturnableId = vResultObj.Id,
                    };

                    var lstMaterialOutwardNonReturnableChallan = await _materialOutwardNonReturnableRepository.GetMaterialOutwardNonReturnableChallanList(vMaterialOutwardNonReturnableChallanSearch_Request);
                    vResultObj.challanList = lstMaterialOutwardNonReturnableChallan.ToList();
                }
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
