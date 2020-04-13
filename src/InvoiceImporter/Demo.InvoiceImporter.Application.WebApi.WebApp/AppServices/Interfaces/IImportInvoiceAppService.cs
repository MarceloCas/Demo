using Demo.Core.Application.AppServices.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.AppServices.Interfaces
{
    public interface IImportInvoiceAppService
        : IAppService
    {
        Task<bool> ImportInvoiceFromXML(ImportInvoiceFromXMLFileViewModel viewModel);
        Task<bool> ImportInvoiceFromCSV(ImportInvoiceFromCSVFileViewModel viewModel);
    }
}
