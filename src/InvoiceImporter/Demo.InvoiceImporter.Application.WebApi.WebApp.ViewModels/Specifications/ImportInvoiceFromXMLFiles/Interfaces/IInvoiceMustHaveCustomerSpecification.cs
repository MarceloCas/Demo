using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromXMLFiles.Interfaces
{
    public interface IInvoiceMustHaveCustomerSpecification
        : ISpecification<InvoiceViewModel>
    {
    }
}
