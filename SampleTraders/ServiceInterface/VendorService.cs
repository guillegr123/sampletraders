using SampleTraders.Data;
using SampleTraders.ServiceModel;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTraders.ServiceInterface
{
    public class VendorService : Service
    {
        private readonly IRepositoryVendor VendorRepository;

        public VendorService(IRepositoryVendor vendorRepository)
        {
            VendorRepository = vendorRepository;
        }

        /// <summary>
        /// GET /vendors
        /// </summary>
        public object Get(Vendors request)
        {
            return new VendorsResponse
            {
                Products = VendorRepository.GetAll()
            };
        }
    }
}