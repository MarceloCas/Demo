using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models
{
    public class HandleRegistration
    {
        public IHandler<Message> Handler { get; set; }
        public double Order { get; set; }
        public bool IsAsync { get; set; }
    }
}
