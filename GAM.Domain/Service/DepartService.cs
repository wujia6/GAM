using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Domain.Entities;
using GAM.Domain.Entities.Aggregates.DepartAgg;
using GAM.Domain.Repository;

namespace GAM.Domain.Service
{
    public class DepartService: EFCoreRepository<Depart>, IDepartService
    {
        //private readonly IRepository<Depart> iRepos;

        public DepartService(GamDbContext cxt, IRepository<Depart> repos): base(cxt)
        {
            //this.iRepos = repos;
        }

        #region ##实现接口
        public override bool Delete(Depart entity)
        {
            return base.Delete(entity);
        }

        public override Depart Find(int id)
        {
            return base.Find(id);
        }

        public override Depart Find(Expression<Func<Depart, bool>> filter, Expression<Func<Depart, object>> include = null)
        {
            return base.Find(filter, include);
        }

        public override bool Insert(Depart entity)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Depart> Query(Expression<Func<Depart, object>> include = null, Expression<Func<Depart, bool>> filter = null, Func<IQueryable<Depart>, IOrderedQueryable<Depart>> orderby = null)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<Depart> Query(int index, int size, out int total, Expression<Func<Depart, bool>> filter = null, Func<IQueryable<Depart>, IOrderedQueryable<Depart>> orderby = null)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Depart entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
