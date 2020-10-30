using AuthorityManagement.IDAL;

namespace AuthorityManagement.DAL
{
    public static class RepositoryFactory
    {
        public static IUserInfoRepository UserInfoRepository
        {
            get { return new UserInfoRepository(); }
        }

        public static IRoleRepository RoleRepository
        {
            get { return new RoleRepository(); }
        }
    }
}
