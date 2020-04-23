using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.IoC;
using Demo.Core.Infra.CrossCutting.IoC.Models;
using Demo.InvoiceImporter.Application.WebApi.WebApp.Adapters.Commands;
using Demo.InvoiceImporter.Application.WebApi.WebApp.Adapters.Commands.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.AppServices;
using Demo.InvoiceImporter.Application.WebApi.WebApp.AppServices.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromCSVFiles;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromCSVFiles.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromXMLFiles;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Specifications.ImportInvoiceFromXMLFiles.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromCSVFiles;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromCSVFiles.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromXMLFiles;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.Validations.ImportInvoiceFromXMLFiles.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.IoC
{
    public class DefaultBootstrapper
        : BootstrapperBase
    {
        public DefaultBootstrapper(
            IServiceCollection services, 
            string tenantCode, 
            string cultureName, 
            LocalizationsEnum localization
            ) : base(services, tenantCode, cultureName, localization)
        {
        }

        public override TypeRegistration[] GetTypeRegistrationCollection()
        {
            return new[] {
                new TypeRegistration(typeof(IImportInvoiceAppService), typeof(ImportInvoiceAppService)),
                new TypeRegistration(typeof(IImportInvoiceCommandAdapter), typeof(ImportInvoiceCommandAdapter)),
                new TypeRegistration(typeof(IImportInvoiceFromXMLFileViewModelIsValidToImportValidation), typeof(ImportInvoiceFromXMLFileViewModelIsValidToImportValidation)),
                new TypeRegistration(typeof(IImportInvoiceFromCSVFileViewModelIsValidToImportValidation), typeof(ImportInvoiceFromCSVFileViewModelIsValidToImportValidation)),
                new TypeRegistration(typeof(IFileLineViewModelIsValidToImportValidation), typeof(FileLineViewModelIsValidToImportValidation)),

                new TypeRegistration(typeof(IInvoiceCSVFileMustHaveOneClientPerInvoiceCodeSpecification), typeof(InvoiceCSVFileMustHaveOneClientPerInvoiceCodeSpecification)),
                new TypeRegistration(typeof(IInvoiceCSVFileMustHaveOneDatePerInvoiceCodeSpecification), typeof(InvoiceCSVFileMustHaveOneDatePerInvoiceCodeSpecification)),
                new TypeRegistration(typeof(IInvoiceCSVFileMustHaveOneProductPerInvoiceCodeSpecification), typeof(InvoiceCSVFileMustHaveOneProductPerInvoiceCodeSpecification)),
                new TypeRegistration(typeof(IInvoiceCSVFileMustHaveOneSequencesPerInvoiceCodeSpecification), typeof(InvoiceCSVFileMustHaveOneSequencesPerInvoiceCodeSpecification)),
                new TypeRegistration(typeof(IInvoiceCSVLineMustHaveCustomerGovernamentalDocumentNumberSpecification), typeof(InvoiceCSVLineMustHaveCustomerGovernamentalDocumentNumberSpecification)),
                new TypeRegistration(typeof(IInvoiceCSVLineMustHaveCustomerNameSpecification), typeof(InvoiceCSVLineMustHaveCustomerNameSpecification)),
                new TypeRegistration(typeof(IInvoiceCSVLineMustHaveInvoiceCodeSpecification), typeof(InvoiceCSVLineMustHaveInvoiceCodeSpecification)),
                new TypeRegistration(typeof(IInvoiceCSVLineMustHaveProductCodeSpecification), typeof(InvoiceCSVLineMustHaveProductCodeSpecification)),
                new TypeRegistration(typeof(IInvoiceCSVLineMustHaveProductNameSpecification), typeof(InvoiceCSVLineMustHaveProductNameSpecification)),

                new TypeRegistration(typeof(IInvoiceItemMustHaveProductSpecification), typeof(InvoiceItemMustHaveProductSpecification)),
                new TypeRegistration(typeof(IInvoiceItemMustHaveSequenceSpecification), typeof(InvoiceItemMustHaveSequenceSpecification)),
                new TypeRegistration(typeof(IInvoiceItemMustHaveUnitPriceSpecification), typeof(InvoiceItemMustHaveUnitPriceSpecification)),
                new TypeRegistration(typeof(IInvoiceLineMustHaveQuantitySpecification), typeof(InvoiceLineMustHaveQuantitySpecification)),
                new TypeRegistration(typeof(IInvoiceMustHaveCodeSpecification), typeof(InvoiceMustHaveCodeSpecification)),
                new TypeRegistration(typeof(IInvoiceMustHaveCustomerSpecification), typeof(InvoiceMustHaveCustomerSpecification)),
                new TypeRegistration(typeof(IInvoiceMustHaveDateSpecification), typeof(InvoiceMustHaveDateSpecification)),
                new TypeRegistration(typeof(IInvoiceMustHaveItensSpecification), typeof(InvoiceMustHaveItensSpecification)),
                new TypeRegistration(typeof(IInvoiceMustHaveUniqueSequencesSpecification), typeof(InvoiceMustHaveUniqueSequencesSpecification))

            };
        }
    }
}
