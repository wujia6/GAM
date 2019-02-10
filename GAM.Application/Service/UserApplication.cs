using GAM.Core.IService;
using GAM.Domain.Entities;
using GAM.Domain.Entities.Aggregates.UserAgg;
using GAM.Core.IManage;

namespace GAM.Core.Service
{
    public class UserApplication : IUserApp
    {
        //����������
        private readonly IUserManage iService;
        //������Ԫ����
        private readonly IUnitOfWork iUnitWork;
        //���캯��
        public UserApplication(GamDbContext context, IUserManage ids)
        {
            this.iService = ids;
            this.iUnitWork = context as IUnitOfWork;
        }

        /// <summary>
        /// ��¼У��
        /// </summary>
        /// <param name="account">��¼�˺�</param>
        /// <param name="password">��¼����</param>
        /// <param name="inputcode">��֤��</param>
        /// <returns>User</returns>
        public User UserLogin(string account, string password, string inputcode)
        {
            // return iService.Single(
            //     filter: u => u.Account == account && u.Password == password,
            //     include: u => u.Roles.Include(r => r.Role.Menus.Include(x => x.Menu)));
            return null;
        }

        /// <summary>
        /// ע��У��
        /// </summary>
        /// <param name="entity">ʵ�����</param>
        /// <returns>bool</returns>
        public bool UserRegister(User entity)
        {
            // if (entity == null)
            //     return false;
            // if (!iService.Add(entity))
            //     return false;
            // return iUnitWork.SaveChanges() > 0;
            return false;
        }
    }
}