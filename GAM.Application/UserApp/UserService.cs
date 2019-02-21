using GAM.Core.Models.UserRoot;
using GAM.Core.Models.UserRoot.Manage;

namespace GAM.Application.UserApp
{
    public class UserService : IUserService
    {
        //����������
        private readonly IUserManage iService;
        //���캯��
        public UserService(IUserManage ids)
        {
            this.iService = ids;
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