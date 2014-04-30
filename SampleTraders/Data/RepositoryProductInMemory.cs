using SampleTraders.Model;
using SampleTraders.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTraders.Data
{
    public class RepositoryProductInMemory : IRepositoryProduct
    {
        private static List<ProductModel> _Products;
        public static List<ProductModel> Products
        {
            get
            {
                if (_Products == null)
                {
                    _Products = new List<ProductModel>()
                            {
                                new ProductModel(){ Guid = "1", Vendor = "Vendor 1",  Name = "Blue Cheese", Qty = 19 },
                                new ProductModel(){ Guid = "2", Vendor = "Vendor 1",  Name = "Red Wine", Qty = 21 },
                                new ProductModel(){ Guid = "3", Vendor = "Vendor 1",  Name = "White Wine", Qty = 10 },
                                new ProductModel(){ Guid = "4", Vendor = "Vendor 2",  Name = "Parmesan Cheese 200gr", Qty = 30 },
                                new ProductModel(){ Guid = "5", Vendor = "Vendor 2",  Name = "Knives set", Qty = 5 }
                            };
                }
                return _Products;
            }
        }

        public List<ProductModel> GetAll()
        {
            return Products;
        }

        public ProductModel GetById(string id)
        {
            return Products.SingleOrDefault(x => x.Guid.Equals(id));
        }

        public void Save(ProductModel product)
        {
            product.Guid = new Guid().ToString();
            Products.Add(product);
        }

        public void Update(ProductModel product)
        {
            var productToUpdate = GetById(product.Guid);
            if (productToUpdate != null)
            {
                int pos = Products.IndexOf(productToUpdate);
                Products.Insert(pos, product);
                Products.Remove(productToUpdate);
            }
        }

        public void DeleteById(string id)
        {
            var productToDelete = GetById(id);
            if (productToDelete != null)
            {
                Products.Remove(productToDelete);
            }
        }
    }
}