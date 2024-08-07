using AVSecurity.Application.Models;
using AVSecurity.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IFoodDeliveryRepository
    {
        Task<int> SaveFoodDelivery(FoodDelivery_Request parameters);

        Task<IEnumerable<FoodDelivery_Response>> GetFoodDeliveryList(BaseSearchEntity parameters);

        Task<FoodDelivery_Response?> GetFoodDeliveryById(int Id);
    }
}
