using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models
{
    public class HandlerRegistration
    {
        public Type MessageType { get; set; }
        public Type HandlerType { get; set; }
        public double Order { get; set; }
        public bool StopOnError { get; set; }
        public bool IsAsync { get; set; }
    }
}
