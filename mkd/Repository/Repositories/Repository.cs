using Entities.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{

    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public ApplicationContext DataContext { get { return ContextFactory.GetDBContext(); } }

        public virtual void Add(T entity)
        {
            DataContext.Set<T>().Add(entity);

        }
        public virtual IEnumerable<T> All()
        {
            return DataContext.Set<T>().AsEnumerable();
        }

        public virtual IEnumerable<T> All(Expression<Func<T, bool>> predicate)
        {
            return DataContext.Set<T>().Where(predicate).AsEnumerable();
        }

        public virtual void Delete(T entity)
        {
            DataContext.Set<T>().Remove(entity);

        }

        public virtual void Edit(T entity)
        {

        }

        public virtual void SaveChanges()
        {

            DataContext.SaveChanges();
        }
    }
}

