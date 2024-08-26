using AVSecurity.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Application.Interfaces
{
    public interface IVendorRepository
    {
        Task<int> SaveVendor(Vendor_Request parameters);

        Task<IEnumerable<Vendor_Response>> GetVendorList(VendorSearch_Request parameters);

        Task<Vendor_Response?> GetVendorById(int Id);
    }
}
