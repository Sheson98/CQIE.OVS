using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Domain
{
    public class BaseEntity<T> : ActiveRecordBase where T : class
    {
        [PrimaryKey(PrimaryKeyType.Native)]
        public virtual int Id { get; set; }
    }
}
