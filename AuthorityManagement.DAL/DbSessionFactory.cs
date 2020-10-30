using AuthorityManagement.IDAL;
using System.Runtime.Remoting.Messaging;

namespace AuthorityManagement.DAL
{
    public class DbSessionFactory
    {
        /// <summary>
        /// 保证了线程内DbSession实例唯一
        /// </summary>
        /// <returns></returns>
        public static IDbSession GetCurrentDbSession()
        {
            //这里的GetData()方法的key不能和上下文的一样
            IDbSession _dbSession = CallContext.GetData("DbSession") as IDbSession;
            if (_dbSession == null)
            {
                _dbSession = new DbSession();

                //将值设置到数据槽里面去
                CallContext.SetData("DbSession", _dbSession);
            }

            return _dbSession;
        }
    }
}
