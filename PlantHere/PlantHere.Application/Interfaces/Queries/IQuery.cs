using MediatR;

namespace PlantHere.Application.Interfaces.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
