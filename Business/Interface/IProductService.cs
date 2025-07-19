using AD_CW_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Business.Interface
{
    interface IProductService
    {
        List<ProductModel> GetAllProducts();
        ProductModel GetProductById(int id);
        bool AddProduct(ProductModel product);
        bool UpdateProduct(ProductModel product);
        bool DeleteProduct(int id);
    }
}
