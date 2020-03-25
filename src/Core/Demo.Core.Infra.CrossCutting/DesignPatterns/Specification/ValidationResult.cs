using System.Collections.Generic;
using System.Linq;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification
{
    public class ValidationResult
    {
        private readonly List<ValidationMessage> _validationMessages = new List<ValidationMessage>();

        public string SummaryMessage { get; set; }
        public bool IsValid
        {
            get
            {
                return !ValidationMessageErrors.Any();
            }
        }

        public IEnumerable<ValidationMessage> Messages
        {
            get
            {
                return _validationMessages;
            }
        }
        public IEnumerable<ValidationMessage> ValidationMessageErrors
        {
            get
            {
                return _validationMessages.Where(q => q.ValidationMessageType == Enums.ValidationMessageTypeEnum.Error);
            }
        }

        public ValidationResult()
        {

        }

        public void AddFromAnotherValidationResult(ValidationResult validationResult)
        {
            foreach (var message in validationResult.Messages)
                Add(message);
        }
        public void Add(ValidationMessage validationMessage)
        {
            _validationMessages.Add(validationMessage);
        }
        public void Remove(ValidationMessage validationMessage)
        {
            _validationMessages.RemoveAll(q => q.Code.Equals(validationMessage.Code));
        }
        public void Add(params ValidationResult[] validationResults)
        {
            if (validationResults != null)
            {
                foreach (var item in
                        from result in validationResults
                        where result != null
                        select result)
                {
                    _validationMessages.AddRange(item.Messages);
                }
            }
        }
    }
}


