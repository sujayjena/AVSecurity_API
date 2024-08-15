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
    public class MaterialOutwardReturnableController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IMaterialOutwardReturnableRepository _materialOutwardReturnableRepository;
        private IFileManager _fileManager;

        public MaterialOutwardReturnableController(IMaterialOutwardReturnableRepository materialOutwardReturnableRepository, IFileManager fileManager)
        {
            _materialOutwardReturnableRepository = materialOutwardReturnableRepository;
            _fileManager = fileManager;

            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveMaterialOutwardReturnable(MaterialOutwardReturnable_Request parameters)
        {
            int result = await _materialOutwardReturnableRepository.SaveMaterialOutwardReturnable(parameters);

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

                    var vMaterialOutwardReturnableChallanObj = new MaterialOutwardReturnableChallan_Request()
                    {
                        Id = items.Id,
                        MaterialOutwardReturnableId = result,
                        ChallanNumber = items.ChallanNumber,
                        ChallanImage = items.ChallanImage,
                        ChallanOriginalFileName = items.ChallanOriginalFileName
                    };

                    int resultvPIIssued = await _materialOutwardReturnableRepository.SaveMaterialOutwardReturnableChallan(vMaterialOutwardReturnableChallanObj);
                }
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMaterialOutwardReturnableList(MaterialOutwardReturnableSearch_Request parameters)
        {
            IEnumerable<MaterialOutwardReturnable_Response> lstRoles = await _materialOutwardReturnableRepository.GetMaterialOutwardReturnableList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetMaterialOutwardReturnableById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _materialOutwardReturnableRepository.GetMaterialOutwardReturnableById(Id);
                if (vResultObj != null)
                {
                    var vMaterialOutwardReturnableChallanSearch_Request = new MaterialOutwardReturnableChallanSearch_Request()
                    {
                        MaterialOutwardReturnableId = vResultObj.Id,
                    };

                    var lstMaterialOutwardReturnableChallan = await _materialOutwardReturnableRepository.GetMaterialOutwardReturnableChallanList(vMaterialOutwardReturnableChallanSearch_Request);
                    vResultObj.challanList = lstMaterialOutwardReturnableChallan.ToList();
                }
                _response.Data = vResultObj;
            }
            return _response;
        }
    }
}
