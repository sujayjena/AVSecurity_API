using AVSecurity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Models
{
    public class FoodDeliveryModel
    {
    }
    public class FoodDelivery_Request : BaseEntity
    {
        public int? ShiftId { get; set; }
        public DateTime? FoodDeliveryDate { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public int? EmployeeId { get; set; }
        public string? ShopName { get; set; }
    }

    public class FoodDelivery_Response : BaseResponseEntity
    {
        public int? ShiftId { get; set; }
        public string? ShiftName { get; set; }
        public DateTime? FoodDeliveryDate { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? ShopName { get; set; }
    }
}
