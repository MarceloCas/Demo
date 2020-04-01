using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.Adapter.Interfaces
{
    public interface IAdapter<TTo, TFrom>
        : IDisposable
    {
        Task<TTo> AdapteeAsync(TFrom source);
    }
}
