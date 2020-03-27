using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Base;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification
{
    public class ValidationResult
    {
        private readonly List<ValidationMessage> _validationMessagesCollection = new List<ValidationMessage>();

        public string SummaryMessage { get; set; }
        public bool IsValid { get { return !ValidationMessageErrors.Any(); } }

        public IEnumerable<ValidationMessage> ValidationMessagesCollection { get { return _validationMessagesCollection; } }
        public IEnumerable<ValidationMessage> ValidationMessageErrors
        {
            get
            {
                return _validationMessagesCollection.Where(q => q.ValidationMessageType == Enums.ValidationMessageTypeEnum.Error);
            }
        }

        public ValidationResult()
        {

        }

        public void AddFromAnotherValidationResult(ValidationResult validationResult)
        {
            foreach (var message in validationResult.ValidationMessagesCollection)
                Add(message);
        }
        public void Add(ValidationMessage validationMessage)
        {
            _validationMessagesCollection.Add(validationMessage);
        }
        public void Remove(ValidationMessage validationMessage)
        {
            _validationMessagesCollection.RemoveAll(q => q.Code.Equals(validationMessage.Code));
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
                    _validationMessagesCollection.AddRange(item.ValidationMessagesCollection);
                }
            }
        }
    }
}


