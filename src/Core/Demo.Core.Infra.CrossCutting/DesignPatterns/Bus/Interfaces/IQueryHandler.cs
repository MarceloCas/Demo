using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public interface IQueryHandler<TQuery>
        : IHandler<TQuery>
        where TQuery : QueryBase
    {
        Task<bool> HandleAsync(TQuery query);
    }
}
