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
using System.Linq;
using SampleTraders.Model;

namespace SampleTraders.ServiceInterface
{
    /// <summary>
    /// ServiceStack restful web service implementation.
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
        public object Get(Products request)
        {
            //return new ProductsResponse
            //{
            //    Products = String.IsNullOrEmpty(request.Vendor)
            //        ? Global.StaticMovieCatalog.GetAll()
            //        : Global.StaticMovieCatalog.GetByVendor(request.Vendor)
            //};

            return new ProductsResponse
            {
                Products = ProductRepository.GetAll().Select(x => new Product(){ Guid = x.Id.ToString(), Name = x.Name, Qty = x.Qty, Vendor = x.Vendor }).ToList()
            };
        }

        /// <summary>
        /// GET /movies/{Id}
        /// </summary>
        public ProductResponse Get(Product product)
        {
            ProductModel p = ProductRepository.GetById(product.Guid);
            return new ProductResponse
            {
                Product = (Product)p
            };
        }

        /// <summary>
        /// POST /movies
        /// returns HTTP Response =>
        /// 201 Created
        /// Location: http://localhost/ServiceStack.MovieRest/movies/{newMovieId}
        /// {newMovie DTO in [xml|json|jsv|etc]}
        /// </summary>
        public object Post(Product product)
        {
            ProductRepository.Save(product);
            ProductModel p = ProductRepository.GetById(product.Guid);
            var newProduct = new ProductResponse
            {
                Product = (Product)p
            };
            return new HttpResult(newProduct)
            {
                StatusCode = HttpStatusCode.Created,
                Headers = {
                    {HttpHeaders.Location, base.Request.AbsoluteUri.CombineWith(product.Id.ToString())}
                }
            };
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
            ProductRepository.DeleteById(request.Guid);

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