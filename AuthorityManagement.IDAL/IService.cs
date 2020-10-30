//引进TT模板的命名空间
//使用TT模板生成代码的片段
using AuthorityManagement.Model;

namespace AuthorityManagement.IDAL
{
    //这里需要一个for循环来遍历数据库中所有的表放置在下面即可，这样就实现了所有的表对应的仓储显示出来了
    public interface IActionGroupRepository : IBaseRepository<ActionGroup>
    {
    }
    public interface IActionInfoRepository : IBaseRepository<ActionInfo>
    {
    }
    public interface IR_UserInfo_ActionInfoRepository : IBaseRepository<R_UserInfo_ActionInfo>
    {
    }
    public interface IR_UserInfo_RoleRepository : IBaseRepository<R_UserInfo_Role>
    {
    }
    public interface IRoleRepository : IBaseRepository<Role>
    {
    }
    public interface IUserInfoRepository : IBaseRepository<UserInfo>
    {
    }
}
