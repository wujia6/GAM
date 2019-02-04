using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Domain.Entities.Aggregates.DepartAgg;
using GAM.Domain.Repository;

namespace GAM.Domain.Service
{
    public class DepartService: EFCoreRepository<Depart>, IDepartService
    {
        private readonly IRepository<Depart> iRepos;

        public DepartService(IRepository<Depart> repos)
        {
            this.iRepos = repos;
        }

        #region ##实现接口
        public bool Delete(Depart entity)
        {
            return entity == null ? false : iRepos.Delete(entity);
        }

        public Depart Find(int id)
        {

            return iRepos.Find(id);
        }

        public Depart Find(Expression<Func<Depart, bool>> filter, Expression<Func<Depart, object>> include = null)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Depart entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Depart> Query(Expression<Func<Depart, object>> include = null, Expression<Func<Depart, bool>> filter = null, Func<IQueryable<Depart>, IOrderedQueryable<Depart>> orderby = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Depart> Query(int index, int size, out int total, Expression<Func<Depart, bool>> filter = null, Func<IQueryable<Depart>, IOrderedQueryable<Depart>> orderby = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(Depart entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
