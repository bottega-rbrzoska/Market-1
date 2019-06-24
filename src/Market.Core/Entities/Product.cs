using System;
using Market.Core.Exceptions;

namespace Market.Core.Entities
{
    // Entity
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        private Product()
        {
        }

        public Product(Guid id, string name, string category, string description, decimal price)
        {
            Id = id == Guid.Empty
                ? throw new ArgumentException("Invalid product ID.", nameof(id))
                : id;
            SetName(name);
            SetCategory(category);
            SetDescription(description);
            SetPrice(price);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidProductNameException();
            }

            if (name.Length > 50)
            {
                throw new InvalidProductNameException();
            }

            Name = name;
        }

        public void SetCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException("Product category is empty.",
                    nameof(category));
            }

            Category = category;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Product description is empty.",
                    nameof(description));
            }

            Description = description;
        }

        public void SetPrice(decimal price)
        {
            if (price < 1 || price > 100000)
            {
                throw new ArgumentException("Invalid product price.",
                    nameof(price));
            }

            Price = price;
        }
    }
}