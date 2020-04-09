using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public delegate Task<bool> CommandHandler<TCommand>(TCommand command) where TCommand : Command;

    public interface ICommandHandler<TCommand>
        : IHandler<TCommand>
        where TCommand : Command
    {
        CommandHandler<TCommand> CommandHandler { get; }
    }
}
