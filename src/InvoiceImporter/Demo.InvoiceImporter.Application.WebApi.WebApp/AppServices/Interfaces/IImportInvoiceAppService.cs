using Demo.Core.Application.AppServices.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
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
