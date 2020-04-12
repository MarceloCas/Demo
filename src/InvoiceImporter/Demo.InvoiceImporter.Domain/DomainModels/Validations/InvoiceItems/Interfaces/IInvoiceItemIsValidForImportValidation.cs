using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Domain.DomainModels.Validations.InvoiceItems.Interfaces
{
    public interface IInvoiceItemIsValidForImportValidation
        : IValidator<InvoiceItem>
    {
    }
}
