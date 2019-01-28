using System;
using System.Threading.Tasks;

namespace GAM.Domain.IComm
{
    public interface IUnitOfWork: IDisposable
    {
        int SaveChanges();

        Task SaveChangesAsync();
    }
}
