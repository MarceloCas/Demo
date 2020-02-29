using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.ValueObjects.Base
{
    public abstract class ValueObjectBase
        : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
