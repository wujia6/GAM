using System;

namespace GAM.Domain.IComm
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();
    }
}
