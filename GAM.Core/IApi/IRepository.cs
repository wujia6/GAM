using System.Linq;
using GAM.Core.Models;

namespace GAM.Core.IApi
{
    public interface IRepository<T> where T: BaseEntity, IAggregateRoot
    {
        ISqlLocalContext IContext { get; }

        IQueryable<T> ModelSet { get; }

        bool InsertAt(T model);

        bool DeleteAt(T model);

        bool UpdateAt(T model);

        T FindBySpecification(ISpecification<T> ispec);

        IQueryable<T> QueryBySpecification(ISpecification<T> ispec);
    }
}
