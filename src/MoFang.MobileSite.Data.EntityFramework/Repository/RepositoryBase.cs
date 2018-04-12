using Microsoft.EntityFrameworkCore;
using MoFang.MobileSite.Domain.Entity;
using MoFang.MobileSite.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MoFang.MobileSite.Data.EntityFramework.Context;

namespace MoFang.MobileSite.Data.EntityFramework.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        protected IServiceProvider serviceProvider { get; private set; }

        public RepositoryBase(IServiceProvider _serviceProvider)
        {
            this.serviceProvider = _serviceProvider;
            this.context = this.serviceProvider.GetService<MoFangMobileSiteContext>();
            entities = context.Set<T>();
        }

        #region CRUD基本方法

        /// <summary>
        /// 获取一个对象
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public Task<T> Get(Expression<Func<T, bool>> exp)
        {
            return entities.FirstOrDefaultAsync(exp);
        }

        /// <summary>
        /// 插入或更新一个对象（自动判断，new出来的就新增，get出来的就更新）
        /// </summary>
        /// <param name="entity"></param>
        public void Save(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                entities.Add(entity);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// 更新一个对象，对象必须与EF建立过追踪关系（Get/Save/Insert后的），不可以更新直接new的对象
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                throw new Exception("对象必须与EF建立追踪关系（Get/Save/Insert后的），不可以更新直接new的对象");
            }
            else
            {
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 删除一个对象
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            if (entity != null)
            {
                entities.Remove(entity);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 删除一个对象（按条件）
        /// </summary>
        /// <param name="exp"></param>
        public void Delete(Expression<Func<T, bool>> exp)
        {
            var result = entities.FirstOrDefaultAsync(exp);
            entities.Remove(result.Result);
            context.SaveChanges();
        }

        /// <summary>
        /// 软删除一个对象（约定删除标记为IsValid，将IsValid字段更新为0）
        /// </summary>
        /// <param name="entity">实体对象</param>
        public void SoftDelete(dynamic entity)
        {
            //这里不能设置State=Modified，否则会导致强制更新所有字段，EF开动追踪后，无需手动设置EntityState，EF会自动对比，只有值变动的字段才会加入update语句
            entity.IsValid = false;
            context.SaveChanges();
        }

        /// <summary>
        /// 软删除一个对象（约定删除标记为IsValid，将IsValid字段更新为0）
        /// </summary>
        /// <param name="exp">查询表达式</param>
        public void SoftDelete(Expression<Func<T, bool>> exp)
        {
            dynamic entity = entities.FirstOrDefaultAsync(exp);
            if (entity != null)
            {
                entity.IsValid = false;
                context.SaveChanges();
            }
        }

        #endregion

        #region 获取列表
        /// <summary>
        /// 获取对象列表（全部）
        /// </summary>
        /// <returns></returns>
        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }

        /// <summary>
        /// 获取对象列表（按条件）
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public Task<List<T>> GetList(Expression<Func<T, bool>> exp)
        {
            return entities.Where(exp).ToListAsync();
        }

        /// <summary>
        /// 获取对象列表（按条件，分页获取）
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="exp">查询表达式，如果需要按条件拼接，可通过ExpressionHelper辅助类生成</param>
        /// <param name="ordering">排序字段</param>
        /// <param name="descending">升序或降序</param>
        /// <param name="pageIndex">页码，从0开始</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public List<T> GetPagerList<TKey>(Expression<Func<T, bool>> exp, Func<T, TKey> ordering, bool descending, int pageIndex, int pageSize)
        {
            if (descending)
            {
                return entities.Where(exp)
                .OrderByDescending(ordering)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();
            }
            else
            {
                return entities.Where(exp)
                .OrderBy(ordering)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();
            }
        }

        /// <summary>
        /// 获取对象列表（按条件，分页获取，out输出总记录数）
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="exp">查询表达式，如果需要按条件拼接，可通过ExpressionHelper辅助类生成</param>
        /// <param name="ordering">排序字段</param>
        /// <param name="descending">升序或降序</param>
        /// <param name="pageIndex">页码，从0开始</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="total">数据总数</param>
        /// <returns></returns>
        public List<T> GetPagerList<TKey>(Expression<Func<T, bool>> exp, Func<T, TKey> ordering, bool descending, int pageIndex, int pageSize, out int total)
        {
            total = entities.Count(exp);

            if (descending)
            {
                return entities.Where(exp)
                .OrderByDescending(ordering)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();
            }
            else
            {
                return entities.Where(exp)
                .OrderBy(ordering)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();
            }
        }

        /// <summary>
        /// 获取对象列表（全部。仅构建表达式树，不真正执行查询，直到调用ToList或Count等方法，可用于查询条件拼接）
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetQueryable()
        {
            return entities.AsQueryable();
        }

        /// <summary>
        /// 获取对象列表（按条件。仅构建表达式树，不真正执行查询，直到调用ToList或Count等方法，可用于查询条件拼接）
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> exp)
        {
            return entities.Where(exp);
        }
        #endregion

        #region 批量操作
        /// <summary>
        /// 批量插入对象
        /// </summary>
        /// <param name="list">要插入的对象集合</param>
        public void BatchInsert(IEnumerable<T> list)
        {
            entities.AddRangeAsync(list);
            context.SaveChanges();
        }

        /// <summary>
        /// 批量更新对象
        /// </summary>
        public void BatchUpdate()
        {
            context.SaveChanges();
        }

        /// <summary>
        /// 批量删除对象
        /// </summary>
        /// <param name="list">要删除的对象集合</param>
        public void BatchDelete(IEnumerable<T> list)
        {
            entities.RemoveRange(list);
            context.SaveChanges();
        }

        /// <summary>
        /// 批量软删除（约定删除标记为IsValid，将IsValid字段更新为0）
        /// </summary>
        /// <param name="list">要删除的对象集合</param>
        public void BatchSoftDelete(IEnumerable<dynamic> list)
        {
            foreach (var entity in list)
            {
                entity.IsValid = false;
            }
            context.SaveChanges();
        }

        /// <summary>
        /// 批量软删除（约定删除标记为IsValid，将IsValid字段更新为0）
        /// </summary>
        /// <param name="exp">查询表达式</param>
        public void BatchSoftDelete(Expression<Func<T, bool>> exp)
        {
            dynamic list = entities.Where(exp);
            foreach (var entity in list)
            {
                entity.IsValid = false;
            }
            context.SaveChanges();
        }

        #endregion
    }
}
