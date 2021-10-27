using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Models;

namespace Assessment.Services
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProduct(int? productId);
        Task<int> AddProduct(Product products);
        Task<int> DeleteProduct(int? productId);
        Task UpdateProduct(Product product,int id);
    }
}
