﻿using System.Linq;
using GAM.Core.IApi;
using GAM.Core.Models.UserRoot;

namespace GAM.Core.Models.DepartRoot
{
    public class DepartManage: IDepartManage
    {
        private readonly IRepository<Depart> iRepos;

        public DepartManage(IRepository<Depart> irepo)
        {
            this.iRepos = irepo;
        }

        public bool AddOrEditAt(Depart model)
        {
            if (model == null)
                return false;
            return model.ID > 0 ? iRepos.UpdateAt(model) : iRepos.InsertAt(model);
        }

        public bool RemoveAt(Depart model)
        {
            if (model == null)
                return false;
            return iRepos.DeleteAt(model);
        }

        public Depart FindBy(ISpecification<Depart> ispec)
        {
            return iRepos.FindBySpecification(ispec);
        }

        public IQueryable<Depart> QueryBy(ISpecification<Depart> ispec)
        {
            return iRepos.QueryBySpecification(ispec);
        }

        public IQueryable<User> GetDepartUsers(ISpecification<User> ispec)
        {
            return iRepos.IContext.Set<User>().Where(ispec.Expression).AsQueryable();
        }
    }
}
