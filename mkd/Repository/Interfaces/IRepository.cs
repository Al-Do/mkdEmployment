using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
   public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        IEnumerable<T> All();
        IEnumerable<T> All(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
