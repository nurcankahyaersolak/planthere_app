using MediatR;

namespace PlantHere.Application.Interfaces.Commands
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}
