using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Enums;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification
{
    public class ValidationMessage
    {
        public string Code { get; private set; }
        public string DefaultDescription { get; private set; }
        public ValidationMessageTypeEnum ValidationMessageType { get; private set; }

        public ValidationMessage(string code, string defaultDescription, ValidationMessageTypeEnum validationMessageType = ValidationMessageTypeEnum.Error)
        {
            Code = code;
            DefaultDescription = defaultDescription;
            ValidationMessageType = validationMessageType;
        }
    }
}


