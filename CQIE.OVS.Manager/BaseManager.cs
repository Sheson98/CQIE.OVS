using Castle.ActiveRecord;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Manager
{
    public class BaseManager<T>:ActiveRecordBase<T>
        where T : class
    {
        public virtual void Add(T t)
        {
            ActiveRecordBase.Create(t);
        }
        public new void Delete(T t)
        {
            ActiveRecordBase.Delete(t);
        }

        public void Delete(int id)
        {
            T t = Get(id);
            if (t != null)
            {
                Delete(t);
            }
        }

        public void DeleAll()
        {
            ActiveRecordBase.DeleteAll(typeof(T));
        }

        public void DelByWhere(string strWhere)
        {
            ActiveRecordBase.DeleteAll(typeof(T), strWhere);
        }

        public new void Update(T t)
        {
            ActiveRecordBase.Update(t);
        }
        public T Get(int id)
        {
            return FindByPrimaryKey(typeof(T), id) as T;
        }

        public IList<T> GetAll()
        {
            return FindAll(typeof(T)) as IList<T>;
        }

        public IList<T> Query(IList<ICriterion> quertConditions)
        {
            Array arr = ActiveRecordBase.FindAll(typeof(T), quertConditions.ToArray());
            return arr as IList<T>;
        }

        public IList<T> FindBySQL(string querysql)
        {
            ISession session = ActiveRecordBase.holder.CreateSession(typeof(T)); //获取管理DeliverForm的session对象
            IQuery query = session.CreateSQLQuery(querysql).AddEntity("arr", typeof(T));//获取满足条件的数据
            IList<T> arr = query.List<T>();
            session.Close();
            return arr;
        }

        /// <summary>
        /// 分页获取满足条件的实体
        /// </summary>
        /// <param name="queryConditions">查询条件</param>
        /// <param name="orderList">排序属性列表</param>
        /// <param name="pageIndex">页码,从1开始</param>
        /// <param name="pageSize">每页实体数</param>
        /// <param name="count">满足条件的实体总数</param>
        /// <returns></returns>
        public IList<T> Query(IList<ICriterion> queryConditions, IList<Order> orderlist,
            int pageIndex, int pageSize, out int count)
        {
            if (queryConditions == null)
            {
                queryConditions = new List<ICriterion>();
            }
            if (orderlist == null)
            {
                orderlist = new List<Order>();
            }
            count = Count(typeof(T), queryConditions.ToArray());//根据查询条件获取满足条件的对象总数
            Array arr = SlicedFindAll(typeof(T), (pageIndex - 1) * pageSize, pageSize, orderlist.ToArray(),
                queryConditions.ToArray());//根据查询条件分页获取对象集合
            return arr as IList<T>;
        }

        /// <summary>
        /// 根据SQL语句获取数据集；
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public IList<T> GetListBySQL(string strsql)
        {
            return FindBySQL(strsql);
        }
    }
}
