using Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS.Base;

namespace Demo.Core.Infra.CrossCutting.DesignPatterns.CQRS
{
    public class Query<TReturn>
        : QueryBase
    {
        public string TenantCode { get; protected set; }
        public TReturn QueryReturn { get; }

        public Query<TReturn> SetTenantCode(string tenantCode)
        {
            TenantCode = tenantCode;

            return this;
        }
    }
}
