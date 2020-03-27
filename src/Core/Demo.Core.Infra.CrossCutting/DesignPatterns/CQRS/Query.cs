using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Models;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS
{
    public class Query<TReturn>
        : QueryBase
    {
        public TReturn QueryReturn { get; }
    }
}
