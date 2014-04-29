using SampleTraders.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleTraders.Data
{
    public class RepositoryProductInMemory : IRepositoryProduct
    {
        private static List<Product> _Products;
        public static List<Product> Products
        {
            get
            {
                if (_Products == null)
                {
                    _Products = new List<Product>()
                            {
                                new Product(){ Id = 1, Vendor = "Vendor 1",  Name = "Blue Cheese", Qty = 19 },
                                new Product(){ Id = 2, Vendor = "Vendor 1",  Name = "Red Wine", Qty = 21 },
                                new Product(){ Id = 3, Vendor = "Vendor 1",  Name = "White Wine", Qty = 10 },
                                new Product(){ Id = 4, Vendor = "Vendor 2",  Name = "Parmesan Cheese 200gr", Qty = 30 },
                                new Product(){ Id = 5, Vendor = "Vendor 2",  Name = "Knives set", Qty = 5 }
                            };
                }
                return _Products;
            }
        }

        public List<ServiceModel.Product> GetAll()
        {
            return Products;
        }

        public ServiceModel.Product GetById(int id)
        {
            return Products.SingleOrDefault(x => x.Id == id);
        }

        public void Save(ServiceModel.Product product)
        {
            product.Id = Products.Max(x => x.Id) + 1;
            Products.Add(product);
        }

        public void Update(ServiceModel.Product product)
        {
            var productToUpdate = GetById(product.Id);
            if (productToUpdate != null)
            {
                int pos = Products.IndexOf(productToUpdate);
                Products.Insert(pos, product);
                Products.Remove(productToUpdate);
            }
        }

        public void DeleteById(int id)
        {
            var productToDelete = GetById(id);
            if (productToDelete != null)
            {
                Products.Remove(productToDelete);
            }
        }
    }
}