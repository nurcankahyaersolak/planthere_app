using MediatR;

namespace PlantHere.Application.CQRS.Base
{
    public class RequestBase : RequestBase<Unit>
    {
        protected RequestBase() : base()
        {
        }
    }

    public class RequestBase<TResult> : IRequest<TResult>
    {

    }
}
