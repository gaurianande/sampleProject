using Ecommerce.Domain.Models;
using ECommerce.Application.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace JWTASPNetCore
{
    public interface IUserRepository : IRepository<User>
    {
       
    }
}