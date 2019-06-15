using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.kernel.Persistence
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Save(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Detached(TEntity entity);

        IQueryable<TEntity> FindAll();
    }
}
