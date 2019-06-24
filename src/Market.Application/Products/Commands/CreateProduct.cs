using System;

namespace Market.Application.Products.Commands
{
    public class CreateProduct : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Category { get; }
        public string Description { get; }
        public decimal Price { get; }

        public CreateProduct(Guid id, string name, string category, string description, decimal price)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Name = name;
            Category = category;
            Description = description;
            Price = price;
        }
    }
}