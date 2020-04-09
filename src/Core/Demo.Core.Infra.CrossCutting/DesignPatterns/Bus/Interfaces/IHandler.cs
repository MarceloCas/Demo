using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models;
using System;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public interface IHandler<out TMessage>
        : IDisposable
        where TMessage : Message
    {

    }
}
