using Entities.Entities;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class Service<T, R> : IService<T>
          where T : BaseEntity
         where R : IRepository<T>
    {
        public virtual R Repository { get; protected set; }
        public void Create(T entity)
        {
            Repository.Add(entity);
            Repository.SaveChanges();
        }

        public void Create(List<T> entities)
        {
            if (entities == null) return;
            foreach (var entity in entities)
            {
                Repository.Add(entity);
            }

            Repository.SaveChanges();
        }

        public void Delete(T entity)
        {
            Repository.Delete(entity);
            Repository.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return Repository.All();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return Repository.All(predicate);
        }
       
        public void Update(T entity)
        {
            Repository.Edit(entity);
            Repository.SaveChanges();
        }
    }
}
