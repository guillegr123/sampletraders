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
using SampleTraders.Extensions.Model;

namespace SampleTraders.ServiceInterface
{
    /// <summary>
    /// ServiceStack restful web service implementation.
    /// </summary>
    public class ProductService : Service
    {
        private readonly IRepositoryProduct ProductRepository;
        private readonly IRepositoryVendor VendorRepository;

        public ProductService(IRepositoryProduct productRepository, IRepositoryVendor vendorRepository)
        {
            ProductRepository = productRepository;
            VendorRepository = vendorRepository;
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
                Products = ProductRepository.GetAll().Select(x => x.ToProduct()).ToList()
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
                Product = p.ToProduct()
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
            var vendorModel = VendorRepository.GetById(product.Vendor.Guid);
            var productModel = product.ToProductModel(vendorModel);
            ProductRepository.Save(productModel);
            var p = ProductRepository.GetById(productModel.ProductId.ToString());
            var newProduct = new ProductResponse
            {
                Product = p.ToProduct()
            };

            return new HttpResult(newProduct)
            {
                StatusCode = HttpStatusCode.Created,
                Headers = {
                    {HttpHeaders.Location, base.Request.AbsoluteUri.CombineWith(newProduct.Product.Guid)}
                }
            };
        }

        /// <summary>
        /// PUT /movies/{id}
        /// </summary>
        public object Put(Product product)
        {
            var vendorModel = VendorRepository.GetById(product.Vendor.Guid);
            ProductRepository.Update(product.ToProductModel(vendorModel));

            return new HttpResult
            {
                StatusCode = HttpStatusCode.NoContent,
                Headers =
                {
                    {HttpHeaders.Location, this.Request.AbsoluteUri.CombineWith(product.Guid)}
                }
            };
        }

        /// <summary>
        /// DELETE /movies/{Id}
        /// </summary>
        public object Delete(Product product)
        {
            ProductRepository.DeleteById(product.Guid);

            return new HttpResult
            {
                StatusCode = HttpStatusCode.NoContent,
                Headers = {
                    {HttpHeaders.Location, this.Request.AbsoluteUri.CombineWith(product.Guid)}
                }
            };
        }
    }
}