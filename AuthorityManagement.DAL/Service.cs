//引进TT模板的命名空间


//使用TT模板生成代码的片段
using AuthorityManagement.IDAL;
using AuthorityManagement.Model;

namespace AuthorityManagement.DAL
{
    //这里需要一个for循环来遍历数据库中所有的表放置在下面即可，这样就实现了所有的表对应的仓储显示出来了
    public partial class ActionGroupRepository : BaseRepository<ActionGroup>, IActionGroupRepository
    {
    }
    public partial class ActionInfoRepository : BaseRepository<ActionInfo>, IActionInfoRepository
    {
    }
    public partial class R_UserInfo_ActionInfoRepository : BaseRepository<R_UserInfo_ActionInfo>, IR_UserInfo_ActionInfoRepository
    {
    }
    public partial class R_UserInfo_RoleRepository : BaseRepository<R_UserInfo_Role>, IR_UserInfo_RoleRepository
    {
    }
    public partial class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
    }
    public partial class UserInfoRepository : BaseRepository<UserInfo>, IUserInfoRepository
    {
    }
}
