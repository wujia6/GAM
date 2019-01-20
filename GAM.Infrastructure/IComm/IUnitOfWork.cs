using System;

namespace GAM.Infrastructure.IComm
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();
    }
}
