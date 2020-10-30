using AuthorityManagement.IDAL;
using AuthorityManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.DAL
{
    /*
     * 虽然DbSession封装的很简单，但是它兼顾了简单工厂模式和SaveChangers方法(当前会话比较重要的功能)， 虽然SaveChangers方法简单的几行
     * 代码，但是我们在这里实现了一个模式，那就是单元工作模式(UintWork)。
     * 单元工作模式，就是批量的把对数据库的操作提交到数据库中去，就是把一系列对数据库的操作封装成一个单元工作，一次性的把单元工作里面
     * 变都提交到数据库里面去，这就是单元工作模式，它的目的就是为了提高跟数据库交互的效率，减少跟数据库交互的次数。
     */
    /// <summary>
    /// 一次跟数据库交互的会话，封装了所以仓储的属性，根据DBSession可以拿到仓储的属性
    /// 代表应用程序跟数据库之间的一次会话，也是数据库访问层的统一入口
    /// </summary>
    public class DbSession: IDbSession
    {
        public IRoleRepository RoleRepository
        {
            get { return new RoleRepository(); }
        }

        public IUserInfoRepository UserInfoRepository
        {
            get { return new UserInfoRepository(); }
        }

        /// <summary>
        /// 代表当前应用程序跟数据库的会话内所有的实体的变化，更新回数据库
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            //调用EF上下文的SaveChange方法
            return EFContextFactory.GetCurrentDbContext().SaveChanges();
        }

        /// <summary>
        /// 执行Sql的方法
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExcuteSql(string strSql, DbParameter[] parameters)
        {
            //EF4.0的执行方法ObjectContext
            //封装一个执行Sql脚本的代码
            //return EFContextFactory.GetCurrentDbContext().ExecuteFunction(strSql, parameters);

            throw new NotImplementedException();
        }
    }
}
