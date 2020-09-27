using CQIE.RIS.Domain;
using CQIE.RIS.Manager;
using CQIE.RIS.Service;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Component
{
    public class BaseComponent<T,M>:IBaseService<T>
        where T:BaseEntity<T>,new()
        where M:BaseManager<T>,new()
    {
        protected M manager = typeof(M).GetConstructor(Type.EmptyTypes).Invoke(null) as M; //Invoke反射

        #region 添加
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            manager.Add(entity);
        }
        #endregion

        #region 删除
        public void DelByWhere(string strWhere)
        {
            manager.DelByWhere(strWhere);
        }

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            manager.Delete(id);
        }

        /// <summary>
        /// 根据实体删除
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            manager.Delete(entity);
        }

        /// <summary>
        /// 删除所有
        /// </summary>
        public void DeleteAll()
        {
            manager.DeleAll();
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找所有实体
        /// </summary>
        /// <returns></returns>
        public IList<T> GetAll()
        {
            return manager.GetAll();
        }
        /// <summary>
        /// 根据id查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetEntity(int id)
        {
            return manager.Get(id);
        }
        /// <summary>
        /// 根据sql语句查找
        /// </summary>
        /// <param name="strSql">查询语句</param>
        /// <returns>查找集合</returns>
        public IList<T> GetListBySQL(string strSql)
        {
            return manager.GetListBySQL(strSql);
        }

        /// <summary>
        /// 分页获取满足条件的实体
        /// </summary>
        /// <param name="queryConditions">查询条件</param>
        /// <param name="orderList">排序属性列表</param>
        /// <param name="pageIndex">页码，从1开始</param>
        /// <param name="pageSize">每页实体数</param>
        /// <param name="count">满足条件的实体总数</param>
        /// <returns></returns>
        public IList<T> Query(IList<ICriterion> queryConditions, IList<Order> orderList,
            int pageIndex, int pageSize, out int count)
        {
            return manager.Query(queryConditions, orderList, pageIndex, pageSize, out count);
        }

        public IList<T> Query(List<ICriterion> queryConditions)
        {
            return manager.Query(queryConditions);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 根据实体修改实体
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            manager.Update(entity);
        }
        #endregion
    }
}
