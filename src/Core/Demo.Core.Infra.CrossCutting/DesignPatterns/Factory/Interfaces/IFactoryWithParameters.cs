using Demo.Core.Infra.CrossCutting.Globalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Factory.Interfaces
{
    public interface IFactoryWithParameters<TReturn, TParameter>
        : IFactory<TReturn>
    {
        Task<TReturn> CreateAsync(TParameter parameter);
    }
}
