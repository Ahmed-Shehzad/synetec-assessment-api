using MediatR;

namespace SynetecAssessmentApi.Foundation.Core.Interfaces
{
    public interface IQueryHandler<in TQuery, TResponse>: IRequestHandler<TQuery, TResponse> where TQuery: IQuery<TResponse>
    {
        
    }
}