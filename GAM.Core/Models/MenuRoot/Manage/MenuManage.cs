﻿using System.Linq;
using GAM.Core.IApi;

namespace GAM.Core.Models.MenuRoot
{
    internal class MenuManage: IMenuManage
    {
        private readonly IRepository<Menu> iRepos;

        public MenuManage(IRepository<Menu> irepos)
        {
            this.iRepos = irepos;
        }

        public bool AddOrEditAt(Menu model)
        {
            if (model == null)
                return false;
            return model.ID !=null ? iRepos.UpdateAt(model) : iRepos.InsertAt(model);
        }

        public bool RemoveAt(ISpecification<Menu> ispec)
        {
            var entity = iRepos.ModelSet.FirstOrDefault(ispec.Expression);
            return entity == null ? false : iRepos.DeleteAt(entity);
        }

        public Menu FindBy(ISpecification<Menu> ispec)
        {
            return iRepos.FindBySpecification(ispec);
        }

        public IQueryable<Menu> QueryBy(ISpecification<Menu> ispec)
        {
            return iRepos.QueryBySpecification(ispec);
        }
    }
}
