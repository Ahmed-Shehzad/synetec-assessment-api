using MediatR;

namespace SynetecAssessmentApi.Foundation.Core.Interfaces
{
    public interface IQuery {}
    
    public interface IQuery<out T>: IRequest<T>, IQuery { }
}