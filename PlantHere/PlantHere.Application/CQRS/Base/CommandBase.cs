using PlantHere.Application.Interfaces.Commands;

namespace PlantHere.Application.CQRS.Base
{
    public class CommandBase<TResult> : RequestBase<TResult>, ICommand<TResult>
    {
    }
}
