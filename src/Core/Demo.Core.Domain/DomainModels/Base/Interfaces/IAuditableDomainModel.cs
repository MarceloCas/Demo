using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.Domain.DomainModels.Base.Interfaces
{
    public interface IAuditableDomainModel
        : IDomainModel
    {
        public string CreationUser { get; }
        public DateTime CreationDate { get; }
        public string ModificationUser { get; }
        public DateTime ModificationDate { get; }
    }
}
