using SampleTraders.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
