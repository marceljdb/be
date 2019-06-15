using be.business.Model;
using be.kernel.Persistence;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace be.business.Persistence
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {

        [Inject]
        public BeModel BeModel { get; set; }

        public abstract IQueryable<TEntity> FindAll();

        public DbSet<TEntity> GetEntityDbSet()
        {
            return BeModel.Set<TEntity>();
        }

        public virtual void Save(TEntity entity)
        {
            GetEntityDbSet().Add(entity);
        }

        public virtual void SaveAndFlush(TEntity entity)
        {
            Save(entity);
            Flush();
        }

        public virtual void Update(TEntity entity)
        {
            Attach(entity);
            BeModel.Entry(entity).State = EntityState.Modified;
        }

        public virtual void UpdateAndFlush(TEntity entity)
        {
            Update(entity);
            Flush();
        }

        public virtual void Delete(TEntity entity)
        {
            GetEntityDbSet().Remove(entity);
        }

        public virtual void DeleteAndFlush(TEntity entity)
        {
            Delete(entity);
            Flush();
        }

        public virtual void SaveAll(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                SaveAndFlush(entity);
            }
        }

        public virtual void SaveAllAndFlush(IEnumerable<TEntity> entities)
        {
            SaveAll(entities);
            Flush();
        }


        public TEntity Attach(TEntity entity)
        {
            return GetEntityDbSet().Attach(entity);
        }

        public void Flush()
        {
            BeModel.SaveChanges();
        }

        public void Detached(TEntity entity)
        {
            BeModel.Entry(entity).State = EntityState.Detached;
        }
    }
}
