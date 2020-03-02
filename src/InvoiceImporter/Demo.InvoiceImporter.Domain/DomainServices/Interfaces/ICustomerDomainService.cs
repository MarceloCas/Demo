﻿using Demo.Core.Domain.DomainServices.Base.Interfaces;
using Demo.InvoiceImporter.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.InvoiceImporter.Domain.DomainServices.Interfaces
{
    public interface ICustomerDomainService
        : IDomainService<Customer>
    {
        Task<Customer> ImportCustomerAsync(string tenantCode, string creationUser, Customer customerToImport);
    }
}
