using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<Product> GetProductByIdAsync(int id);
        public Task AddProductAsync(Product product);
        public Task<List<Product>> GetProductsByNameAsync(string name);
    }
}
