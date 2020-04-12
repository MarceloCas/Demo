using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public delegate Task<bool> CustomEventHandler<TEvent>(TEvent @event) where TEvent : Event;

    public interface IEventHandler<TEvent>
        : IHandler<TEvent>
        where TEvent : Event
    {
        CustomEventHandler<TEvent> EventHandler { get; }
    }
}
