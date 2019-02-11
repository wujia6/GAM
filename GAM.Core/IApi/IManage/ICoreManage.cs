using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Core.Models;

namespace GAM.Core.IApi.IManage
{
    public interface ICoreManage<T> where T: BaseEntity, IAggregateRoot
    {
        bool AddOrEditAt(T model);

        bool RemoveAt(T model);

        T FindBy(Expression<Func<T, bool>> express);

        IQueryable<T> QueryBy(Expression<Func<T, bool>> express);
    }
}