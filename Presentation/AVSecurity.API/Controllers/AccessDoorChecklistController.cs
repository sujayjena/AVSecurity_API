using AVSecurity.Application.Enums;
using AVSecurity.Application.Interfaces;
using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Globalization;

namespace AVSecurity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessDoorChecklistController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IAccessDoorChecklistRepository _accessDoorChecklistRepository;

        public AccessDoorChecklistController(IAccessDoorChecklistRepository accessDoorChecklistRepository)
        {
            _accessDoorChecklistRepository = accessDoorChecklistRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveAccessDoorChecklist(AccessDoorChecklist_Request parameters)
        {
            int result = await _accessDoorChecklistRepository.SaveAccessDoorChecklist(parameters);

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
        public async Task<ResponseModel> GetAccessDoorChecklistList(AccessDoorChecklistSearch_Request parameters)
        {
            IEnumerable<AccessDoorChecklist_Response> lstRoles = await _accessDoorChecklistRepository.GetAccessDoorChecklistList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetAccessDoorChecklistById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _accessDoorChecklistRepository.GetAccessDoorChecklistById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> ExportAccessDoorChecklistData()
        {
            _response.IsSuccess = false;
            byte[] result;
            int recordIndex;
            ExcelWorksheet WorkSheet1;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var request = new AccessDoorChecklistSearch_Request();

            IEnumerable<AccessDoorChecklist_Response> lstSizeObj = await _accessDoorChecklistRepository.GetAccessDoorChecklistList(request);

            using (MemoryStream msExportDataFile = new MemoryStream())
            {
                using (ExcelPackage excelExportData = new ExcelPackage())
                {
                    WorkSheet1 = excelExportData.Workbook.Worksheets.Add("AccessDoorChecklist");
                    WorkSheet1.TabColor = System.Drawing.Color.Black;
                    WorkSheet1.DefaultRowHeight = 12;

                    //Header of table
                    WorkSheet1.Row(1).Height = 20;
                    WorkSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    WorkSheet1.Row(1).Style.Font.Bold = true;

                    WorkSheet1.Cells[1, 1].Value = "Shift";
                    WorkSheet1.Cells[1, 2].Value = "Date";
                    WorkSheet1.Cells[1, 3].Value = "Location";
                    WorkSheet1.Cells[1, 4].Value = "Building";
                    WorkSheet1.Cells[1, 5].Value = "Floor";
                    WorkSheet1.Cells[1, 6].Value = "Reported To";

                    WorkSheet1.Cells[1, 7].Value = "CreatedDate";
                    WorkSheet1.Cells[1, 8].Value = "CreatedBy";


                    recordIndex = 2;

                    foreach (var items in lstSizeObj)
                    {
                        WorkSheet1.Cells[recordIndex, 1].Value = items.ShiftName;
                        WorkSheet1.Cells[recordIndex, 2].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        WorkSheet1.Cells[recordIndex, 2].Value = items.AccesDoorDate;
                        WorkSheet1.Cells[recordIndex, 3].Value = items.LocationName;
                        WorkSheet1.Cells[recordIndex, 4].Value = items.BuildingName;
                        WorkSheet1.Cells[recordIndex, 5].Value = items.FloorName;
                        WorkSheet1.Cells[recordIndex, 6].Value = items.ReportedTo;

                        WorkSheet1.Cells[recordIndex, 7].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        WorkSheet1.Cells[recordIndex, 7].Value = items.CreatedDate;
                        WorkSheet1.Cells[recordIndex, 8].Value = items.CreatorName;

                        recordIndex += 1;
                    }

                    WorkSheet1.Column(1).AutoFit();
                    WorkSheet1.Column(2).AutoFit();
                    WorkSheet1.Column(3).AutoFit();
                    WorkSheet1.Column(4).AutoFit();
                    WorkSheet1.Column(5).AutoFit();
                    WorkSheet1.Column(6).AutoFit();
                    WorkSheet1.Column(7).AutoFit();
                    WorkSheet1.Column(8).AutoFit();

                    excelExportData.SaveAs(msExportDataFile);
                    msExportDataFile.Position = 0;
                    result = msExportDataFile.ToArray();
                }
            }

            if (result != null)
            {
                _response.Data = result;
                _response.IsSuccess = true;
                _response.Message = "Record Exported successfully";
            }

            return _response;
        }

    }
}
