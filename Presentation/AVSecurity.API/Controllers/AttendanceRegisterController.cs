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
    public class AttendanceRegisterController : CustomBaseController
    {
        private ResponseModel _response;
        private readonly IAttendanceRegisterRepository _attendanceRegisterRepository;

        public AttendanceRegisterController(IAttendanceRegisterRepository attendanceRegisterRepository)
        {
            _attendanceRegisterRepository = attendanceRegisterRepository;
            _response = new ResponseModel();
            _response.IsSuccess = true;
        }

        #region Location

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> SaveAttendanceRegister(AttendanceRegister_Request parameters)
        {
            int result = await _attendanceRegisterRepository.SaveAttendanceRegister(parameters);

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
        public async Task<ResponseModel> GetAttendanceRegisterList(AttendanceRegisterSearch_Request parameters)
        {
            IEnumerable<AttendanceRegister_Response> lstRoles = await _attendanceRegisterRepository.GetAttendanceRegisterList(parameters);
            _response.Data = lstRoles.ToList();
            _response.Total = parameters.Total;
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> GetAttendanceRegisterById(int Id)
        {
            if (Id <= 0)
            {
                _response.Message = "Id is required";
            }
            else
            {
                var vResultObj = await _attendanceRegisterRepository.GetAttendanceRegisterById(Id);
                _response.Data = vResultObj;
            }
            return _response;
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ResponseModel> ExportAttendanceRegisterData()
        {
            _response.IsSuccess = false;
            byte[] result;
            int recordIndex;
            ExcelWorksheet WorkSheet1;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var request = new AttendanceRegisterSearch_Request();

            IEnumerable<AttendanceRegister_Response> lstSizeObj = await _attendanceRegisterRepository.GetAttendanceRegisterList(request);

            using (MemoryStream msExportDataFile = new MemoryStream())
            {
                using (ExcelPackage excelExportData = new ExcelPackage())
                {
                    WorkSheet1 = excelExportData.Workbook.Worksheets.Add("AttendanceRegister");
                    WorkSheet1.TabColor = System.Drawing.Color.Black;
                    WorkSheet1.DefaultRowHeight = 12;

                    //Header of table
                    WorkSheet1.Row(1).Height = 20;
                    WorkSheet1.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    WorkSheet1.Row(1).Style.Font.Bold = true;

                    WorkSheet1.Cells[1, 1].Value = "Date and In Time";
                    WorkSheet1.Cells[1, 2].Value = "Date and Out Time";
                    WorkSheet1.Cells[1, 3].Value = "Employee Name";

                    WorkSheet1.Cells[1, 4].Value = "CreatedDate";
                    WorkSheet1.Cells[1, 5].Value = "CreatedBy";


                    recordIndex = 2;

                    foreach (var items in lstSizeObj)
                    {
                        WorkSheet1.Cells[recordIndex, 1].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        WorkSheet1.Cells[recordIndex, 1].Value = items.DateInTime;
                        WorkSheet1.Cells[recordIndex, 2].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        WorkSheet1.Cells[recordIndex, 2].Value = items.DateOutTime;
                        WorkSheet1.Cells[recordIndex, 3].Value = items.EmployeeName;
                      
                        WorkSheet1.Cells[recordIndex, 4].Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                        WorkSheet1.Cells[recordIndex, 4].Value = items.CreatedDate;
                        WorkSheet1.Cells[recordIndex, 5].Value = items.CreatorName;

                        recordIndex += 1;
                    }

                    WorkSheet1.Column(1).AutoFit();
                    WorkSheet1.Column(2).AutoFit();
                    WorkSheet1.Column(3).AutoFit();
                    WorkSheet1.Column(4).AutoFit();
                    WorkSheet1.Column(5).AutoFit();

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

        #endregion
    }
}
