using AuthorityManagement.Common;
using AuthorityManagement.Model;

namespace AuthorityManagement.IBLL
{
    public interface IUserInfoService : IBaseService<UserInfo>
    {
        /// <summary>
        /// 在这里添加一个用户登录信息的约束
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        //UserInfo CheckUserInfo(UserInfo userInfo);
        LoginResult CheckUserInfo(UserInfo userInfo);
    }
}
