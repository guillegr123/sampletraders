using SampleTraders.Model;
using System.Collections.Generic;

namespace SampleTraders.Data
{
    public interface IRepositoryProduct
    {
        List<ProductModel> GetAll();
        ProductModel GetById(string id);
        void Save(ProductModel product);
        void Update(ProductModel product);
        void DeleteById(string id);
    }
}
