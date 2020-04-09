using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS
{
    public class Query<TReturn>
        : QueryBase
    {
        public TReturn QueryReturn { get; }
    }
}
