using System.ComponentModel.DataAnnotations;

namespace GAM.WebUI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="登录账号不能为空")]
        public string UserAccount { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "请输入登录密码")]
        public string UserPassword { get; set; }

        public bool RememberMe { get; set; }
    }
}
