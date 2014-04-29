using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTraders.ServiceModel
{
    /// <summary>
    /// Define your ServiceStack web service response (i.e. Response DTO).
    /// </summary>
    public class ProductResponse
    {
        /// <summary>
        /// Gets or sets the movie.
        /// </summary>
        public Product Product { get; set; }
    }

    /// <summary>
    /// Define your ServiceStack web service response (i.e. Response DTO).
    /// </summary>
    public class ProductsResponse
    {
        /// <summary>
        /// Gets or sets the list of products.
        /// </summary>
        public List<Product> Products { get; set; }
    }

    /// <summary>
    /// Define your ServiceStack web service request (i.e. Request DTO).
    /// </summary>
    /// <remarks>The route is defined here rather than in the AppHost.</remarks>
    [Api("GET or DELETE a single movie by Id. Use POST to create a new Movie and PUT to update it")]
    [Route("/products", "POST,PUT,PATCH,DELETE")]
    [Route("/products/{Id}")]
    public class Product : IReturn<ProductResponse>
    {
        /// <summary>
        /// Initializes a new instance of the movie.
        /// </summary>
        public Product()
        {
            //this.Vendor = "";
        }

        /// <summary>
        /// Gets or sets the id of the movie. The id will be automatically incremented when added.
        /// </summary>
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public string Vendor { get; set; }
    }

    /// <summary>
    /// Define your ServiceStack web service request (i.e. Request DTO).
    /// </summary>
    /// <remarks>The route is defined here rather than in the AppHost.</remarks>
    [Api("Find movies by genre, or all movies if no genre is provided")]
    [Route("/products", "GET, OPTIONS")]
    [Route("/products/vendors/{Vendor}")]
    public class Products : IReturn<ProductsResponse>
    {
        public string Vendor { get; set; }
    }
}