using System;
using System.Collections.Generic;
using System.Net;
using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.Text;

namespace SampleTraders
{
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
    /// Create your ServiceStack restful web service implementation.
    /// </summary>
    public class ProductService : Service
    {
        /// <summary>
        /// GET /movies
        /// GET /movies/genres/{Genre}
        /// </summary>
        public object Get(Products request)
        {
            return new ProductsResponse
            {
                Products = String.IsNullOrEmpty(request.Vendor)
                    ? Global.StaticMovieCatalog.GetAll()
                    : Global.StaticMovieCatalog.GetByVendor(request.Vendor)
            };
        }

        /// <summary>
        /// GET /movies/{Id}
        /// </summary>
        public ProductResponse Get(Product movie)
        {
            return new ProductResponse
            {
                Product = Global.StaticMovieCatalog.GetById(movie.Id),
            };
        }

        /// <summary>
        /// POST /movies
        /// returns HTTP Response =>
        /// 201 Created
        /// Location: http://localhost/ServiceStack.MovieRest/movies/{newMovieId}
        /// {newMovie DTO in [xml|json|jsv|etc]}
        /// </summary>
        public object Post(Product movie)
        {
            Global.StaticMovieCatalog.Save(movie);
            var newMovieId = movie.Id;

            var newMovie = new ProductResponse
            {
                Product = Global.StaticMovieCatalog.GetById(newMovieId),
            };

            return new HttpResult(newMovie)
            {
                StatusCode = HttpStatusCode.Created,
                Headers = {
                    {HttpHeaders.Location, base.Request.AbsoluteUri.CombineWith(newMovieId.ToString())}
                }
            };
        }

        /// <summary>
        /// PUT /movies/{id}
        /// </summary>
        public object Put(Product movie)
        {
            Global.StaticMovieCatalog.Update(movie);

            return new HttpResult
            {
                StatusCode = HttpStatusCode.NoContent,
                Headers =
                {
                    {HttpHeaders.Location, this.Request.AbsoluteUri.CombineWith(movie.Id.ToString())}
                }
            };
        }

        /// <summary>
        /// DELETE /movies/{Id}
        /// </summary>
        public object Delete(Product request)
        {
            Global.StaticMovieCatalog.DeleteById(request.Id);

            return new HttpResult
            {
                StatusCode = HttpStatusCode.NoContent,
                Headers = {
                    {HttpHeaders.Location, this.Request.AbsoluteUri.CombineWith(request.Id.ToString())}
                }
            };
        }
    }
}