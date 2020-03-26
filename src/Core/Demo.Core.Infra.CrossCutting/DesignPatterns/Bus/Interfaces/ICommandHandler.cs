using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public interface ICommandHandler<TCommand>
        : IHandler<TCommand>
        where TCommand : Command
    {

    }
}
