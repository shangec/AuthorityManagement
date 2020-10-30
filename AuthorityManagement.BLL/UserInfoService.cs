using AuthorityManagement.DAL;
using AuthorityManagement.IBLL;
using AuthorityManagement.IDAL;
using AuthorityManagement.Model;

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
    }
}
