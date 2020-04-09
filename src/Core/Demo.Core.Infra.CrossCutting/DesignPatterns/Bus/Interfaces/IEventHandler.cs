using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public delegate Task<bool> EventHandler<TEvent>(TEvent @event) where TEvent : Event;

    public interface IEventHandler<TEvent>
        : IHandler<TEvent>
        where TEvent : Event
    {
        EventHandler<TEvent> EventHandler { get; }
    }
}
