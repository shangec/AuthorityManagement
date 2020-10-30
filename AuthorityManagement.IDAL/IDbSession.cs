using System.Data.Common;

namespace AuthorityManagement.IDAL
{
    public interface IDbSession
    {
        //每个表对应的实体仓储对象
        IRoleRepository RoleRepository { get; }
        IUserInfoRepository UserInfoRepository { get; }

        /// <summary>
        /// 将当前应用程序跟数据库的会话内所有实体的变化更新回数据库
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        //EF4.0的写法
        //int ExcuteSql(string strSql,ObjectParameter[] parameters)

        //EF5.0的写法
        /// <summary>
        /// 执行Sql语句的方法
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExcuteSql(string strSql, DbParameter[] parameters);
    }
}
