using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public interface IQueryHandler<TQuery>
        : IHandler<TQuery>
        where TQuery : Query
    {
    }
}
