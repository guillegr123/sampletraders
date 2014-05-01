using SampleTraders.Model;
using System.Collections.Generic;

namespace SampleTraders.Data
{
    public interface IRepositoryVendor
    {
        List<VendorModel> GetAll();
        VendorModel GetById(string id);
    }
}
