using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Enums;

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
