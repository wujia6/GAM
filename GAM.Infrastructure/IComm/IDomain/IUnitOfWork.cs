using System;

namespace GAM.Infrastructure.IComm.IDomain
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();
    }
}
