using CQIE.RIS.Domain;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Service
{
    public interface IBaseService<T> where T: BaseEntity<T>,new ()
    {
        #region 添加
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">具体实体</param>
        void Add(T entity);
        #endregion

        #region 删除
        /// <summary>
        /// 根据Id删除实体
        /// </summary>
        /// <param name="id">具体id</param>
        void Delete(int id);

        /// <summary>
        /// 根据实体删除实体
        /// </summary>
        /// <param name="entity">具体实体</param>
        void Delete(T entity);

        /// <summary>
        /// 删除所有
        /// </summary>
        void DeleteAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        void DelByWhere(string strWhere);
        #endregion

        #region 更新
        /// <summary>
        /// 根据实体修改
        /// </summary>
        /// <param name="entity">具体实体</param>
        void Update(T entity);
        #endregion

        #region 查找
        /// <summary>
        /// 根据id查找实体
        /// </summary>
        /// <param name="id">待查id</param>
        /// <returns></returns>
        T GetEntity(int id);
        /// <summary>
        /// 查找所有
        /// </summary>
        /// <returns></returns>
        IList<T> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryConditions"></param>
        /// <returns></returns>
        IList<T> Query(List<ICriterion> queryConditions);

        /// <summary>
        /// 分页查询功能
        /// </summary>
        /// <param name="queryConditions">查询条件</param>
        /// <param name="orderList">排序列表</param>
        /// <param name="pageIndex">页码索引</param>
        /// <param name="pageSize">每页行数</param>
        /// <param name="count">总记录数</param>
        /// <returns></returns>
        IList<T> Query(IList<ICriterion> queryConditions, IList<Order> orderList, int pageIndex, int pageSize, out int count);
        IList<T> GetListBySQL(string strSql);
        #endregion
    }
}
