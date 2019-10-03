using System.Threading.Tasks;

namespace Market.Application
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}