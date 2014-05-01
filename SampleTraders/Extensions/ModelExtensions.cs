using MongoDB.Bson;
using SampleTraders.Model;
using SampleTraders.ServiceModel;

namespace SampleTraders.Extensions.Model
{
    public static class ModelExtensions
    {
        public static Product ToProduct(this ProductModel pm)
        {
            return new Product
            {
                Guid = pm.ProductId.ToString(),
                Name = pm.Name,
                Qty = pm.Qty,
                Vendor = pm.Vendor.ToVendor()
            };
        }

        public static ProductModel ToProductModel(this Product p, VendorModel vm)
        {
            return new ProductModel
            {
                ProductId = (p.Guid == null) ? default(ObjectId) : ObjectId.Parse(p.Guid),
                Name = p.Name,
                Qty = p.Qty,
                Vendor = vm
            };
        }

        public static Vendor ToVendor(this VendorModel vm)
        {
            return new Vendor
            {
                Guid = vm.VendorId.ToString(),
                Name = vm.Name
            };
        }
    }
}