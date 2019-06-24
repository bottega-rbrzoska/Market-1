using System;
using System.Collections.Generic;
using System.Linq;
using Market.Web.Models;

namespace Market.Web.Services
{
    public class ProductsService : IProductsService
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Huawei P30",
                Category = "Phones",
                Description = "Lorem ipsum...",
                Price = 3500
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "IPhone X",
                Category = "Phones",
                Description = "Lorem ipsum...",
                Price = 5000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Dell XPS 15",
                Category = "Notebooks",
                Description = "Lorem ipsum...",
                Price = 8000
            }
        };

        public IEnumerable<Product> Browse() => _products;

        public void Create(Guid id, string name, string category, string description, decimal price)
            => _products.Add(new Product
            {
                Id = id,
                Name = name,
                Category = category,
                Description = description,
                Price = price
            });

        public void Delete(Guid id)
        {
            var product = Get(id);
            if (product is null)
            {
                return;
            }

            _products.Remove(product);
        }

        public Product Get(Guid id)
            => _products.SingleOrDefault(p => p.Id == id);
    }
}