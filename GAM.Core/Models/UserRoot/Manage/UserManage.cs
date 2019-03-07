using System;
using System.Linq;
using GAM.Core.IApi;

namespace GAM.Core.Models.UserRoot
{
    public class UserManage: IUserManage
    {
        private readonly IRepository<User> iRepos;

        public UserManage(IRepository<User> irepos)
        {
            this.iRepos = irepos;
        }

        public bool AddOrEditAt(User model)
        {
            if (model==null)
                return false;
            return model.ID > 0 ? iRepos.UpdateAt(model) : iRepos.InsertAt(model);
        }

        public bool RemoveAt(ISpecification<User> ispec)
        {
            throw new NotImplementedException();
        }

        public User FindBy(ISpecification<User> ispec)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> QueryBy(ISpecification<User> ispec = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserRole> GetRolesByUser(ISpecification<UserRole> ispec)
        {
            throw new NotImplementedException();
        }
    }
}
