using SampleTraders.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTraders.Data
{
    public interface IRepositoryVendor
    {
        List<Vendor> GetAll();
    }
}
