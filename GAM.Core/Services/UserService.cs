using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Core.IApi;
using GAM.Core.IApi.IManage;
using GAM.Core.Models.UserRoot;
using GAM.Core.Repository;

namespace GAM.Core.Services
{
    internal class UserService: CoreService<User>, IUserManage
    {
        public UserService(IEfCoreRepository<User> irepo): base(irepo) { }
   
        public IQueryable<UserRole> GetRolesByUser(Expression<Func<UserRole, bool>> express)
        {
            ISpecification<UserRole> ispec = Specification<UserRole>.Eval(express);
            return IRepository.IContext.Set<UserRole>().Where(ispec.Expression).AsQueryable();
        }
    }
}
