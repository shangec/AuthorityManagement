﻿using AuthorityManagement.IDAL;
using AuthorityManagement.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace AuthorityManagement.DAL
{
    /// <summary>
    /// 实现对数据库的操作（增删改查）的基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> where T : class, new()
    {
        //创建EF框架的上下文
        //private DataModelContainer db = new DataModelContainer();

        //EF上下文的实例必须保证线程内唯一
        private DbContext db = EFContextFactory.GetCurrentDbContext();

        /// <summary>
        /// 实现对数据的添加功能，添加实现EF框架的引用
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            //EF4.0的写法 添加实体
            //db.CreateObjectSet<T>().AddObject(entity);

            //EF5.0的写法
            db.Entry<T>(entity).State = System.Data.EntityState.Added;

            db.SaveChanges();

            return entity;
        }

        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            //EF4.0的写法
            //db.CreateObjectSet<T>().Addach(entity);
            //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);

            //EF5.0的写法
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = System.Data.EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            //EF4.0的写法
            //db.CreateObjectSet<T>().Addach(entity);
            //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Detached);

            //EF5.0的写法
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Deleted;

            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// 实现对数据库的查询 --简单查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Func<T, bool> whereLambda)
        {
            //EF4.0的写法
            //return db.CreateObjectSet<T>().Where<T>(whereLambda).AsQueryable()

            //EF5.0的写法
            return db.Set<T>().Where<T>(whereLambda).AsQueryable();
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
            //EF4.0和上面的查询一样

            //EF5.0
            var temp = db.Set<T>().Where<T>(whereLambda);
            total = temp.Count();//得到总得条数

            //排序，获取当前页的数据
            if (isAsc)
            {
                temp = temp.OrderBy<T, S>(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))//跳过多少条
                    .Take<T>(pageSize).AsQueryable();//取出多少条
            }
            else
            {
                temp = temp.OrderByDescending<T, S>(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize);
            }

            return temp.AsQueryable();
        }
    }
}
