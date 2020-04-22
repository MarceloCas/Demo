using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromCSVFiles.Interfaces
{
    public interface IInvoiceCSVLineMustHaveProductCodeSpecification
        : ISpecification<FileLineViewModel>
    {
    }
}
