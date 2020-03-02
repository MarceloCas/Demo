namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces
{
    public interface ISelfValidator
    {
        ValidationResult ValidationResult
        {
            get;
        }

        bool IsValid();
        void Validate();
    }
}


