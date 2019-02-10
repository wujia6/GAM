using System;

namespace GAM.Core.IApi
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();
    }
}
