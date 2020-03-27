using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications
{
    public class DomainNotification
        : Message
    {
        public DomainNotificationTypeEnum Type { get; set; }
        public string Code { get; set; }
        public string DefaultDescription { get; set; }
    }
}
