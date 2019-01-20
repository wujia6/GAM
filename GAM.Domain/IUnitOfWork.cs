using System;

namespace GAM.Domain
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();
    }
}
