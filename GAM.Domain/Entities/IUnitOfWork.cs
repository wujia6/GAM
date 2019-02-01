using System;

namespace GAM.Domain.Entities
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();
    }
}
