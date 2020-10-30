using System;
using System.Linq;

namespace AuthorityManagement.IBLL
{
    public interface IBaseService<T> where T : class, new()
    {
        /// <summary>
        /// 实现对数据库的添加功能，添加实现EF框架的引用
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T AddEntity(T entity);
        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateEntity(T entity);
        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteEntity(T entity);
        /// <summary>
        /// 实现对数据库的查询 --简单查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(Func<T, bool> whereLambda);
        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <typeparam name="S">按照某个类进行排序</typeparam>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="total">总条数</param>
        /// <param name="whereLambda">取得排序的条件</param>
        /// <param name="isAsc">如何排序，根据升序还是倒序</param>
        /// <param name="orderByLambda">根据哪个字段进行排序</param>
        /// <returns></returns>
        IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderByLambda);
    }
}
