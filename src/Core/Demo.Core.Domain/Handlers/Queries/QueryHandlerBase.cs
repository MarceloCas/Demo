using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Domain.Handlers.Queries
{
    public abstract class QueryHandlerBase<TQuery>
        : IQueryHandler<TQuery>
        where TQuery : QueryBase
    {
        public abstract Task<bool> HandleAsync(TQuery query);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
