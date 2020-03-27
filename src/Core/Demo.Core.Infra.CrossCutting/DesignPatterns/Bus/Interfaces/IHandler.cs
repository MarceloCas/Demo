using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces
{
    public interface IHandler<out TMessage>
        : IDisposable
        where TMessage : Message
    {

    }
}
