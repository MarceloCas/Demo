using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Enums;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification
{
    public class ValidationMessage
    {
        public string Sender { get; set; }
        public string Code { get; private set; }
        public string DefaultDescription { get; private set; }
        public ValidationMessageTypeEnum ValidationMessageType { get; private set; }

        public ValidationMessage(string sender, string code, string defaultDescription, ValidationMessageTypeEnum validationMessageType = ValidationMessageTypeEnum.Error)
        {
            Sender = sender;
            Code = code;
            DefaultDescription = defaultDescription;
            ValidationMessageType = validationMessageType;
        }
    }
}


