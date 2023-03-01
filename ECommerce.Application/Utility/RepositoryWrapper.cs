using Ecommerce.Domain;
using ECommerce.Application.Repositories;
using JWTASPNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Utility
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        IUserRepository User { get; }
        Task Save();
    }

    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IProductRepository _product;
        private IUserRepository _user;
        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_repoContext);
                }
                return _product;
            }
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
