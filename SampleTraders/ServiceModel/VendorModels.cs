using SampleTraders.Model;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTraders.ServiceModel
{
    /// <summary>
    /// ServiceStack web service vendors list response (i.e. Response DTO).
    /// </summary>
    public class VendorsResponse
    {
        /// <summary>
        /// Gets or sets the list of products.
        /// </summary>
        public List<Vendor> Vendors { get; set; }
    }

    public class Vendor
    {
        public string Guid { set; get; }
        public string Name { set; get; }
    }

    /// <summary>
    /// Define your ServiceStack web service vendors list request (i.e. Request DTO).
    /// </summary>
    /// <remarks>The route is defined here rather than in the AppHost.</remarks>
    [Api("Get all vendors.")]
    [Route("/vendors", "GET, OPTIONS")]
    public class Vendors : IReturn<VendorsResponse>
    {
    }
}