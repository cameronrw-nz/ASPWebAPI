using ASPWebAPI.Models;
using System.Collections.Generic;

namespace ASPWebAPI.Services
{
    public interface IProductsDataAccess
    {
        IEnumerable<Product> GetProducts();

        void InsertProduct(Product insertedProduct);

        void UpdateProduct(Product updatedProduct);

        void DeleteProduct(int productId);
    }
}