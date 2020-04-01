using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Domain.Handlers.Commands
{
    public abstract class CommandHandlerBase<TCommand>
        : ICommandHandler<TCommand>
        where TCommand : Command
    {
        public abstract Task<bool> HandleAsync(TCommand command);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
