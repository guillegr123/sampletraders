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
        public List<Vendor> Products { get; set; }
    }

    public class Vendor : VendorModel
    {
    }

    /// <summary>
    /// Define your ServiceStack web service vendors list request (i.e. Request DTO).
    /// </summary>
    /// <remarks>The route is defined here rather than in the AppHost.</remarks>
    [Api("Find movies by genre, or all movies if no genre is provided")]
    [Route("/vendors", "GET, OPTIONS")]
    public class Vendors : IReturn<VendorsResponse>
    {
    }
}