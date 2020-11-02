using AuthorityManagement.Common;
using System.Web.Mvc;

namespace AuthorityManagement.UI.Portal.Controllers
{
    public class LoginController : Controller
    {
        private AuthorityManagement.IBLL.IUserInfoService _userInfoService = new AuthorityManagement.BLL.UserInfoService();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckUserInfo(AuthorityManagement.Model.UserInfo userInfo)
        {
            var loginUserInfo = _userInfoService.CheckUserInfo(userInfo);
            //if (loginUserInfo != null)
            //{
            //    return Content("OK");
            //}
            //else
            //{
            //    return Content("用户名或密码错误");
            //}
            string userInfoError = "";
            switch (loginUserInfo)
            {
                case LoginResult.PwdError:
                    userInfoError = "密码输入错误";
                    break;
                case LoginResult.UserNotExist:
                    userInfoError = "用户名输入错误";
                    break;
                case LoginResult.UserIsNull:
                    userInfoError = "用户名不能为空";
                    break;
                case LoginResult.PwdIsNull:
                    userInfoError = "密码不能为空";
                    break;
                case LoginResult.Ok:
                    userInfoError = "OK";
                    break;
                default:
                    userInfoError = "未知错误，请您检查您的数据库";
                    break;
            }
            return Content(userInfoError);
        }
    }
}