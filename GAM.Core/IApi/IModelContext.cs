using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GAM.Core.IApi
{
    public interface IModelContext: IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;

        EntityEntry Entry(object entity);
    }
}
