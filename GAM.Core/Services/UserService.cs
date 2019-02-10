using System;
using System.Linq;
using System.Linq.Expressions;
using GAM.Core.IApi;
using GAM.Core.IApi.IManage;
using GAM.Core.Models.UserRoot;
using GAM.Core.Repository;

namespace GAM.Core.Services
{
    public class UserService: IUserManage
    {
        private readonly IEfCoreRepository<User> iRepo;

        public UserService(IEfCoreRepository<User> irepo)
        {
            this.iRepo = irepo;
        }

        public bool AddOrEdit(User user)
        {
            return user.ID > 0 ? iRepo.UpdateAt(user) : iRepo.InsertAt(user);
        }

        public bool Remove(int userId)
        {
            var user = FindBy(express: u => u.ID == userId);
            if (user == null)
                return false;
            return iRepo.DeleteAt(user);
        }

        public User FindBy(Expression<Func<User, bool>> express)
        {
            ISpecification<User> ispec = Specification<User>.Eval(express);
            return iRepo.FindBySpecification(ispec);
        }

        public IQueryable<User> QueryBy(Expression<Func<User, bool>> express)
        {
            ISpecification<User> ispec = Specification<User>.Eval(express);
            return iRepo.QueryBySpecification(ispec);
        }
        
        public IQueryable<UserRole> GetRolesByUser(Expression<Func<UserRole, bool>> express)
        {
            ISpecification<UserRole> ispec = Specification<UserRole>.Eval(express);
            return iRepo.IContext.Set<UserRole>().Where(ispec.Expression).AsQueryable();
        }
    }
}
