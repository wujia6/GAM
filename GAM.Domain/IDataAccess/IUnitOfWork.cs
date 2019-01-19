using System;

namespace GAM.Domain.IDataAccess
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();
    }
}
