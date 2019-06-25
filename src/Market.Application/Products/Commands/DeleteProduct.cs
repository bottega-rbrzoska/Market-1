using System;

namespace Market.Application.Products.Commands
{
    public class DeleteProduct : ICommand
    {
        public Guid Id { get; }

        public DeleteProduct(Guid id)
        {
            Id = id;
        }
    }
}