using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public interface ICommandHandler<TCommand>
        : IHandler<TCommand>
        where TCommand : Command
    {
        Task<bool> HandleAsync(TCommand command);
    }
}
