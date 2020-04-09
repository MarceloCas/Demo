using Demo.Core.Infra.CrossCutting.DesignPatterns.Bus.Interfaces;
using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;
using System;

namespace Demo.Core.Domain.Handlers.Queries
{
    public abstract class QueryHandlerBase<TQuery>
        : IQueryHandler<TQuery>
        where TQuery : QueryBase
    {
        // Properties
        public QueryHandler<TQuery> QueryHandler { get; protected set; }

        // Constructors
        protected QueryHandlerBase()
        {
            QueryHandler = GetQueryHandler();
        }

        // Abstract Methods
        protected abstract QueryHandler<TQuery> GetQueryHandler();

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
