namespace Demo.InvoiceImporter.Domain.DomainModels.Interfaces
{
    public interface ICustomer
        : Core.Domain.DomainModels.Interfaces.ICustomer
    {
        string GovernamentalDocumentNumber { get; }
    }
}
