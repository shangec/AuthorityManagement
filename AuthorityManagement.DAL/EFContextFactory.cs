using AuthorityManagement.Model;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace AuthorityManagement.DAL
{
    public class EFContextFactory
    {
        /// <summary>
        /// 帮我们返回当前线程内的数据库上下文，如果当前线程内没有上下文，那么创建一个上下文，
        /// 并保证上下文实例在线程内都是惟一的
        /// </summary>
        /// <returns></returns>
        public static DbContext GetCurrentDbContext()
        {
            //CallContext:是线程内部唯一的独用的数据槽（一块内存空间）
            //传递DbContext进去，获取实例的信息，在这里进行强制转换
            DbContext dbContext = CallContext.GetData("DbContext") as DbContext;
            if (dbContext==null)//线程在数据槽里面没有此上下文
            {
                //如果不存在上下文的话，创建一个EF上下文
                dbContext = new DataModelContainer();

                //创建一个，放到数据槽中去
                CallContext.SetData("DbContext", dbContext);
            }

            return dbContext;
        }
    }
}
