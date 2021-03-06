﻿using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.InvoiceImporter.Application.WebApi.WebApp.AppServices;
using Demo.InvoiceImporter.Application.WebApi.WebApp.AppServices.Interfaces;
using Demo.InvoiceImporter.Application.WebApi.WebApp.Tests.Base;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromCSVFile;
using Demo.InvoiceImporter.Application.WebApi.WebApp.ViewModels.ImportInvoiceFromXMLFile;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.InvoiceImporter.Application.WebApi.WebApp.Tests.AppServices
{
    public class ImportInvoiceAppServiceTest
        : TestBase<ImportInvoiceAppServiceTest>
    {
        public ImportInvoiceAppServiceTest(
            ITestOutputHelper output,
            string tenantCode = "dev",
            string creationUser = "unitTest",
            LocalizationsEnum localization = LocalizationsEnum.Default,
            string cultureName = "en-US"
            ) : base(output, tenantCode, creationUser, localization, cultureName)
        {

        }

        [Fact]
        [Trait(nameof(ImportInvoiceAppService), "ImportInvoiceFromXML_Success")]
        public async Task ImportInvoiceFromXML_Success()
        {
            await RunWithTelemetry(async () =>
            {
                var importInvoiceAppService = Bootstrapper.GetService<IImportInvoiceAppService>();

                await importInvoiceAppService.ImportInvoiceFromXML(new ImportInvoiceFromXMLFileViewModel
                {
                    InvoiceViewModelCollection = new List<InvoiceViewModel>
                    {
                        new InvoiceViewModel
                        {
                            Code = "INVOICE_001",
                            Date = DateTime.UtcNow,
                            Customer = new CustomerViewModel{ Name = "CUSTOMER 1", GovernamentalDocumentNumber = "123" },
                            InvoiceItemCollection = new List<InvoiceItemViewModel>
                            {
                                new InvoiceItemViewModel
                                {
                                    Sequence = 1,
                                    Quantity = 10,
                                    UnitPrice = 2.5,
                                    Product = new ProductViewModel{ Code = "PRODUCT_001", Name="Product A" }
                                },
                                new InvoiceItemViewModel
                                {
                                    Sequence = 2,
                                    Quantity = 15,
                                    UnitPrice = 3.75,
                                    Product = new ProductViewModel{ Code = "PRODUCT_002", Name="Product B" }
                                }
                            }
                        },
                        new InvoiceViewModel
                        {
                            Code = "INVOICE_002",
                            Date = DateTime.UtcNow,
                            Customer = new CustomerViewModel{ Name = "CUSTOMER 1", GovernamentalDocumentNumber = "123" },
                            InvoiceItemCollection = new List<InvoiceItemViewModel>
                            {
                                new InvoiceItemViewModel
                                {
                                    Sequence = 1,
                                    Quantity = 10,
                                    UnitPrice = 2.5,
                                    Product = new ProductViewModel{ Code = "PRODUCT_001", Name="Product A" }
                                },
                                new InvoiceItemViewModel
                                {
                                    Sequence = 2,
                                    Quantity = 5,
                                    UnitPrice = 30,
                                    Product = new ProductViewModel{ Code = "PRODUCT_003", Name="Product C" }
                                }
                            }
                        }
                    }
                });

                return true;
            },
            1);

        }

        [Fact]
        [Trait(nameof(ImportInvoiceAppService), "ImportInvoiceFromCSV_Success")]
        public async Task ImportInvoiceFromCSV_Success()
        {
            await RunWithTelemetry(async () =>
            {
                var importInvoiceAppService = Bootstrapper.GetService<IImportInvoiceAppService>();

                var importInvoiceFromCSVFileViewModel = new ImportInvoiceFromCSVFileViewModel();
                for (int invoiceIndex = 1; invoiceIndex <= 10; invoiceIndex++)
                {
                    var invoiceCode = invoiceIndex.ToString();
                    var invoiceDate = DateTime.UtcNow.AddDays(invoiceIndex).ToString("yyyy-MM-dd");

                    var customerGovernamentalDocumentNumber = invoiceIndex.ToString();
                    var customerName = $"Customer {customerGovernamentalDocumentNumber}";

                    var productCode = invoiceIndex.ToString();
                    var productName = $"Product {productCode}";

                    for (int lineIndex = 1; lineIndex <= 3; lineIndex++)
                    {
                        importInvoiceFromCSVFileViewModel.FileLineCollection.Add(new FileLineViewModel
                        {
                            InvoiceCode = invoiceCode,
                            InvoiceDate = invoiceDate,
                            CustomerGovernamentalDocumentNumber = customerGovernamentalDocumentNumber,
                            CustomerName = customerName,
                            ProductCode = productCode,
                            ProductName = productName,
                            InvoiceItemQuantity = "1",
                            InvoiceItemSequence = lineIndex.ToString(),
                            InvoiceItemUnitPrice = "1.00"
                        });
                    }
                }

                await importInvoiceAppService.ImportInvoiceFromCSV(importInvoiceFromCSVFileViewModel);

                return true;
            },
            1000);

        }
    }
}
