using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Interfaces;

namespace DAL.Repository
{
    public  class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ForumContext Context;

        public Repository(ForumContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

      
        public TEntity Find(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Delete(int id)
        {
            Context.Set<TEntity>().Remove(Find(id));
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
