using Demo.Core.Application.AppServices.Base;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification;
using Demo.InvoiceImporter.Application.WebApi.WebApp.AppServices.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.AppServices
{
    public class ImportInvoiceAppService
        : AppServiceBase,
        IImportInvoiceAppService
    {
        public Task<ValidationResult> ImportInvoiceFromCSV(ImportInvoiceFromCSVFileViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ImportInvoiceFromXML(ImportInvoiceFromXMLFileViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
