﻿using Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Specification.Base;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using System;
using System.Threading.Tasks;

namespace Demo.Core.Domain.DomainModels.Base.Specifications.DomainModels
{
    public class DomainModelMustHaveCreationDateSpecification
        : SpecificationBase<DomainModelBase>,
        IDomainModelMustHaveCreationDateSpecification
    {
        public DomainModelMustHaveCreationDateSpecification(
            IBus bus,
            IGlobalizationConfig globalizationConfig
            ) : base(bus, globalizationConfig)
        {
        }

        public override async Task<bool> IsSatisfiedByAsync(DomainModelBase entity)
        {
            return await Task.FromResult(entity?.CreationDate ?? DateTime.MinValue) > DateTime.MinValue;
        }
    }
}
