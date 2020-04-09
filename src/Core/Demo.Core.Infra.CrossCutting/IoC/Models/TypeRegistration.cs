using Demo.Core.Infra.CrossCutting.IoC.Models.Enums;
using System;

namespace Demo.Core.Infra.CrossCutting.IoC.Models
{
    public class TypeRegistration
    {
        public Type AbstractionType { get; private set; }
        public Type ConcreteType { get; private set; }
        public RegistrationLifeTimeEnum RegistrationLifeTime { get; private set; }
        public Func<IServiceProvider, object> FactoryFunction { get; private set; }

        public TypeRegistration(Type concreteType, RegistrationLifeTimeEnum registrationLifeTime = RegistrationLifeTimeEnum.Scoped)
        {
            ConcreteType = concreteType;
            RegistrationLifeTime = registrationLifeTime;
        }
        public TypeRegistration(
            Type abstractionType,
            Type concreteType,
            RegistrationLifeTimeEnum registrationLifeTime = RegistrationLifeTimeEnum.Scoped)
            : this(concreteType, registrationLifeTime)
        {
            AbstractionType = abstractionType;
        }
        public TypeRegistration(
            Type abstractionType,
            Func<IServiceProvider, object> factoryFunction,
            RegistrationLifeTimeEnum registrationLifeTime = RegistrationLifeTimeEnum.Scoped)
        {
            AbstractionType = abstractionType;
            FactoryFunction = factoryFunction;
            RegistrationLifeTime = registrationLifeTime;
        }
    }
}
