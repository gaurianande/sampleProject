using Ecommerce.Domain.Models;
using ECommerce.Application.Repositories;
using ECommerce.Application.ServiceBus;
using ECommerce.Application.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private IRepositoryWrapper _productRepository;
        private ServiceBusSender _serviceBusSender;

        public ProductService(IRepositoryWrapper productRepository, ServiceBusSender serviceBusSender)
        {
            _productRepository = productRepository;
            _serviceBusSender = serviceBusSender;
        }

        public async Task AddProductAsync(Product product)
        {
            //await _productRepository.Product.Create(product);
            await _serviceBusSender.SendMessage(product);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var result= await _productRepository.Product.FindByCondition(x => x.Id == id);
            return result;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var result = await _productRepository.Product.FindAll();
            return result.ToList();
        }

        public async Task<List<Product>> GetProductsByNameAsync(string name)
        {
            var result = await _productRepository.Product.FindAllByCondition(x => x.Name.Contains(name));
            return result.ToList();
        }
    }
}
