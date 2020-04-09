using System;

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
