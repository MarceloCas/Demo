using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.DomainModels.Validations.Invoices.Interfaces
{
    public interface IInvoiceIsValidForImportValidation
        : IValidator<Invoice>
    {
    }
}
