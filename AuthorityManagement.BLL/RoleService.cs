using AuthorityManagement.DAL;
using AuthorityManagement.IBLL;
using AuthorityManagement.Model;

namespace AuthorityManagement.BLL
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        public override void SetCurrentRepository()
        {
            CurrentRepository = RepositoryFactory.RoleRepository;
        }
    }
}
