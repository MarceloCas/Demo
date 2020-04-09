using System;

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
