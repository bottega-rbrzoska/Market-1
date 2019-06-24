using System.Collections.Generic;
using Market.Web.Models;

namespace Market.Web.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> Browse();
    }
}