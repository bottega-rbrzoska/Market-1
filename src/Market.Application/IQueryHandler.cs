using System.Threading.Tasks;

namespace Market.Application
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : class, IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}