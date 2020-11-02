using AuthorityManagement.Common;
using AuthorityManagement.DAL;
using AuthorityManagement.IBLL;
using AuthorityManagement.IDAL;
using AuthorityManagement.Model;
using System.Linq;

namespace AuthorityManagement.BLL
{
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        public override void SetCurrentRepository()
        {
            CurrentRepository = RepositoryFactory.UserInfoRepository;
        }
        //访问DAL实现CRUD
        ////private UserInfoRepository _userInfoRepository = new UserInfoRepository();

        //依赖接口编程
        ////private IUserInfoRepository _userInfoRepository = new UserInfoRepository();
        //private IUserInfoRepository _userInfoRepository = RepositoryFactory.UserInfoRepository;

        //public UserInfo AddUserInfo(UserInfo userInfo)
        //{
        //    return _userInfoRepository.AddEntity(userInfo);
        //}

        //public bool UpdateUserInfo(UserInfo userInfo)
        //{
        //    return _userInfoRepository.UpdateEntity(userInfo);
        //}

        //public UserInfo CheckUserInfo(UserInfo userInfo)
        //{
        //    return _DbSession.UserInfoRepository.LoadEntities(u => u.UName == userInfo.UName && u.Pwd == userInfo.Pwd).FirstOrDefault();
        //}

        public LoginResult CheckUserInfo(UserInfo userInfo)
        {
            if (string.IsNullOrEmpty(userInfo.UName))
            {
                return LoginResult.UserIsNull;
            }
            if (string.IsNullOrEmpty(userInfo.Pwd))
            {
                return LoginResult.PwdIsNull;
            }

            //如果不为空的话，则去数据库中查询
            //在这里回去数据库查是否有数据，如果没有的话就会返回一个空值
            var loginUserInfoCheck = _DbSession.UserInfoRepository.LoadEntities(u => u.UName == userInfo.UName).FirstOrDefault();

            //对返回结果进行判断
            if (loginUserInfoCheck==null)
            {
                return LoginResult.UserNotExist;
            }
            if (loginUserInfoCheck.Pwd!=userInfo.Pwd)
            {
                return LoginResult.PwdError;
            }
            else
            {
                return LoginResult.Ok;
            }
            //return _DbSession.UserInfoRepository.LoadEntities(u => u.UName == userInfo.UName && u.Pwd == userInfo.Pwd).FirstOrDefault();
        }
    }
}
