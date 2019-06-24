using System;
using System.Collections.Generic;
using Market.Web.Models;

namespace Market.Web.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> Browse();
        void Create(Guid id, string name, string category, string description, decimal price);
        void Delete(Guid id);
        Product Get(Guid id);
    }
}