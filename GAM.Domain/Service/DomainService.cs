using System;
using System.Collections.Generic;
using System.Text;
using GAM.Infrastructure.IComm.IDomain;
using GAM.Infrastructure.IComm.IApplication;

namespace GAM.Domain.Service
{
    public class DomainService<T>: IService<T> where T:class, IAggregareRoot
    {
        private readonly IRepository<T> efCore;

        public DomainService(IRepository<T> irepos)
        {
            this.efCore = irepos;
        }
    }
}
