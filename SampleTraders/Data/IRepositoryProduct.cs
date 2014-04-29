using SampleTraders.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTraders.Data
{
    public interface IRepositoryProduct
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Save(Product movie);
        void Update(Product movie);
        void DeleteById(int id);
    }
}
