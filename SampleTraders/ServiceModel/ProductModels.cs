﻿using SampleTraders.Model;
using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTraders.ServiceModel
{
    /// <summary>
    /// ServiceStack web service product response (i.e. Response DTO).
    /// </summary>
    public class ProductResponse
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public Product Product { get; set; }
    }

    /// <summary>
    /// ServiceStack web service products list response (i.e. Response DTO).
    /// </summary>
    public class ProductsResponse
    {
        /// <summary>
        /// Gets or sets the list of products.
        /// </summary>
        public List<Product> Products { get; set; }
    }

    /// <summary>
    /// Define ServiceStack web service product request (i.e. Request DTO).
    /// </summary>
    /// <remarks>The route is defined here rather than in the AppHost.</remarks>
    [Api("GET or DELETE a single movie by Id. Use POST to create a new Movie and PUT to update it")]
    [Route("/products", "POST,PUT,PATCH,DELETE")]
    [Route("/products/{Guid}")]
    public class Product : ProductModel, IReturn<ProductResponse>
    {
        /// <summary>
        /// Initializes a new instance of the product.
        /// </summary>
        public Product()
        {
            //this.Vendor = "";
        }
    }

    /// <summary>
    /// Define ServiceStack web service products list request (i.e. Request DTO).
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