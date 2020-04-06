﻿using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus;
using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers;
using Demo.Core.Infra.CrossCutting.DesignPatterns.DomainNotifications.Handlers.Interface;
using Demo.Core.Infra.CrossCutting.Globalization;
using Demo.Core.Infra.CrossCutting.Globalization.Enums;
using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using Demo.Core.Infra.CrossCutting.IoC.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.IoC
{
    public abstract class BootstrapperBase
    {
        // Attributes
        private readonly ServiceProvider _serviceProvider;
        private readonly IServiceCollection _services;
        private readonly TypeRegistration[] _typeRegistrationCollection;

        private readonly string _tenantCode;
        private readonly string _cultureName;
        private readonly LocalizationsEnum _localization;

        // Properties
        protected IServiceCollection Services
        {
            get
            {
                return _services;
            }
        }

        protected string TenantCode
        {
            get
            {
                return _tenantCode;
            }
        }
        protected string CultureName
        {
            get
            {
                return _cultureName;
            }
        }
        protected LocalizationsEnum Localization
        {
            get
            {
                return _localization;
            }
        }
        
        public TypeRegistration[] TypeRegistrationCollection
        {
            get
            {
                return _typeRegistrationCollection;
            }
        }

        // Constructores
        protected BootstrapperBase(
            IServiceCollection services,
            string tenantCode,
            string cultureName,
            LocalizationsEnum localization)
        {
            _services = services;

            _tenantCode = tenantCode;
            _cultureName = cultureName;
            _localization = localization;

            _typeRegistrationCollection = GetTypeRegistrationCollection();
            if (_typeRegistrationCollection?.Any() == true)
            {
                foreach (var typeRegistration in _typeRegistrationCollection)
                {
                    if (typeRegistration.AbstractionType == null
                        && typeRegistration.ConcreteType != null)
                    {
                        switch (typeRegistration.RegistrationLifeTime)
                        {
                            case Models.Enums.RegistrationLifeTimeEnum.Transient:
                                services.AddTransient(typeRegistration.ConcreteType);
                                break;
                            case Models.Enums.RegistrationLifeTimeEnum.Scoped:
                                services.AddScoped(typeRegistration.ConcreteType);
                                break;
                            case Models.Enums.RegistrationLifeTimeEnum.Singleton:
                                services.AddSingleton(typeRegistration.ConcreteType);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("Invalid RegistrationLifeTime");
                        }
                    }
                    else
                    {
                        switch (typeRegistration.RegistrationLifeTime)
                        {
                            case Models.Enums.RegistrationLifeTimeEnum.Transient:
                                {
                                    if (typeRegistration.FactoryFunction == null)
                                        services.AddTransient(typeRegistration.AbstractionType, typeRegistration.ConcreteType);
                                    else
                                        services.AddTransient(typeRegistration.AbstractionType, serviceProvider => {
                                            return typeRegistration.FactoryFunction(serviceProvider);
                                        });
                                    break;
                                }
                            case Models.Enums.RegistrationLifeTimeEnum.Scoped:
                                {
                                    if (typeRegistration.FactoryFunction == null)
                                        services.AddScoped(typeRegistration.AbstractionType, typeRegistration.ConcreteType);
                                    else
                                        services.AddScoped(typeRegistration.AbstractionType, serviceProvider => {
                                            return typeRegistration.FactoryFunction(serviceProvider);
                                        });
                                    break;
                                }
                            case Models.Enums.RegistrationLifeTimeEnum.Singleton:
                                {
                                    if (typeRegistration.FactoryFunction == null)
                                        services.AddSingleton(typeRegistration.AbstractionType, typeRegistration.ConcreteType);
                                    else
                                        services.AddSingleton(typeRegistration.AbstractionType, serviceProvider => {
                                            return typeRegistration.FactoryFunction(serviceProvider);
                                        });
                                    break;
                                }
                            default:
                                throw new ArgumentOutOfRangeException("Invalid RegistrationLifeTime");
                        }
                    }
                }
            }

            RegisterLocalTypes(services, _typeRegistrationCollection);

            _serviceProvider = services.BuildServiceProvider();
        }

        // Private methods
        private void RegisterLocalTypes(IServiceCollection services, TypeRegistration[] typeRegistrationCollection)
        {
            services.AddScoped<IGlobalizationConfig>(serviceProvider =>
            {
                return new GlobalizationConfig(CultureName, Localization);
            });
            services.AddScoped<IInMemoryDefaultDomainNotificationHandler, InMemoryDefaultDomainNotificationHandler>();

            services.AddScoped<IBus>(serviceProvider => {
                return new InMemoryBus(serviceProvider, _typeRegistrationCollection);
            });
        }

        // Abstract Methods
        public abstract TypeRegistration[] GetTypeRegistrationCollection();

        // Public Methods
        public object GetServiceObject(Type abstractionType)
        {
            return _serviceProvider.GetService(abstractionType);
        }
        public object GetServiceObject<TAbstraction>()
        {
            return GetServiceObject(typeof(TAbstraction));
        }
        public TAbstraction GetService<TAbstraction>()
        {
            return (TAbstraction)GetServiceObject<TAbstraction>();
        }

        public IEnumerable<object> GetServiceObjects(Type abstractionType)
        {
            return _serviceProvider.GetServices(abstractionType);
        }
        public IEnumerable<TAbstraction> GetServices<TAbstraction>()
        {
            return (IEnumerable<TAbstraction>)GetServiceObjects(typeof(TAbstraction));
        }
    }
}
