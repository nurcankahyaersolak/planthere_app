using PlantHere.Application.Interfaces.Queries;

namespace PlantHere.Application.CQRS.Base
{
    public abstract class QueryBase<TResult> : RequestBase<TResult>, IQuery<TResult>
    {
    }
}
