using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public delegate Task<bool> QueryHandler<TQuery>(TQuery query) where TQuery : QueryBase;

    public interface IQueryHandler<TQuery>
        : IHandler<TQuery>
        where TQuery : QueryBase
    {
        QueryHandler<TQuery> QueryHandler { get; }
    }
}
