using AuthorityManagement.DAL;
using AuthorityManagement.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace AuthorityManagement.BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        //当前仓储
        public IBaseRepository<T> CurrentRepository { get; set; }

        //DbSession的存放
        //public DbSession _DbSession = new DbSession();
        public IDbSession _DbSession = DbSessionFactory.GetCurrentDbSession();

        /// <summary>
        /// 基类的构造函数
        /// </summary>
        public BaseService()
        {
            SetCurrentRepository(); //构造函数里面去调用了，此设置当前仓储的抽象方法
        }
        //约束
        public abstract void SetCurrentRepository();//子类必须实现

        /// <summary>
        /// 实现对数据库的添加功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            //调用T对应的仓储来做添加工作
            var addEnttity = CurrentRepository.AddEntity(entity);
            _DbSession.SaveChanges();
            return addEnttity;
        }

        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            CurrentRepository.UpdateEntity(entity);

            return _DbSession.SaveChanges() > 0;
        }

        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            CurrentRepository.DeleteEntity(entity);

            return _DbSession.SaveChanges()>0;
        }

        /// <summary>
        /// 实现对数据库的查询 --简单查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Func<T, bool> whereLambda)
        {
            return CurrentRepository.LoadEntities(whereLambda);
        }

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
        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderByLambda)
        {
            return CurrentRepository.LoadPageEntities(pageIndex, pageSize, out total, whereLambda, isAsc, orderByLambda);
        }
    }
}
