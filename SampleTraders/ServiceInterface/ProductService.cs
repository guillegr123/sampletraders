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
using SampleTraders.Data;
using SampleTraders.ServiceModel;

namespace SampleTraders.ServiceInterface
{
    /// <summary>
    /// Create your ServiceStack restful web service implementation.
    /// </summary>
    public class ProductService : Service
    {
        private readonly IRepositoryProduct ProductRepository;

        public ProductService(IRepositoryProduct productRepository)
        {
            ProductRepository = productRepository;
        }

        /// <summary>
        /// GET /products
        /// GET /products/vendors/{Vendor}
        /// </summary>
        public List<Product> Get(Products request)
        {
            //return new ProductsResponse
            //{
            //    Products = String.IsNullOrEmpty(request.Vendor)
            //        ? Global.StaticMovieCatalog.GetAll()
            //        : Global.StaticMovieCatalog.GetByVendor(request.Vendor)
            //};

            return ProductRepository.GetAll();
        }

        /// <summary>
        /// GET /movies/{Id}
        /// </summary>
        public Product Get(Product product)
        {
            return ProductRepository.GetById(product.Id);
        }

        /// <summary>
        /// POST /movies
        /// returns HTTP Response =>
        /// 201 Created
        /// Location: http://localhost/ServiceStack.MovieRest/movies/{newMovieId}
        /// {newMovie DTO in [xml|json|jsv|etc]}
        /// </summary>
        public Product Post(Product product)
        {
            ProductRepository.Save(product);
            return product;
        }

        /// <summary>
        /// PUT /movies/{id}
        /// </summary>
        public object Put(Product product)
        {
            ProductRepository.Update(product);

            return new HttpResult
            {
                StatusCode = HttpStatusCode.NoContent,
                Headers =
                {
                    {HttpHeaders.Location, this.Request.AbsoluteUri.CombineWith(product.Id.ToString())}
                }
            };
        }

        /// <summary>
        /// DELETE /movies/{Id}
        /// </summary>
        public object Delete(Product request)
        {
            ProductRepository.DeleteById(request.Id);

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