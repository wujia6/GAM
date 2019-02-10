using System.Linq;
using GAM.Core.Models;

namespace GAM.Core.IApi
{
    public interface IEfCoreRepository<T> where T: BaseEntity, IAggregateRoot
    {
        bool Add(T model);

        bool Remove(T model);

        bool Edit(T model);

        T FindBySpecification(ISpecification<T> ispec);

        IQueryable<T> QueryBySpecification(ISpecification<T> ispec);
    }
}
