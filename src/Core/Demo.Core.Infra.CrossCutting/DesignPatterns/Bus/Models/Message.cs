using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models
{
    public abstract class Message
    {
        public Guid Id { get; set; }
        public string MessageType { get; set; }
        public TimeSpan TimeStamp { get; set; }

        public Message()
        {
            Id = Guid.NewGuid();
            MessageType = GetType().Name;
            TimeStamp = DateTime.UtcNow.TimeOfDay;
        }
    }
}
