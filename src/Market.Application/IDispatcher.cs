using System.Threading.Tasks;

namespace Market.Application
{
    public interface IDispatcher
    {
        Task SendAsync<T>(T command) where T : ICommand;
    }
}