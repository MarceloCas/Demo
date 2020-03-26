using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Bus
{
    public abstract class Message
    {
        public Guid Id { get; set; }
        public TimeSpan TimeStamp { get; set; }

        public Message()
        {
            Id = Guid.NewGuid();
            TimeStamp = DateTime.UtcNow.TimeOfDay;
        }
    }
}
