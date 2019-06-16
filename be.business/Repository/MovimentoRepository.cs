using be.business.Model;
using be.business.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be.business.Repository
{
    public class MovimentoRepository : RepositoryBase<MovimentoEntity>
    {
        public override IQueryable<MovimentoEntity> FindAll()
        {
            return BeModel.Movimento;
        }

        public MovimentoEntity FindFirst()
        {
            return BeModel.Movimento.FirstOrDefault();
        }

        public MovimentoEntity FindById(int id)
        {
            return BeModel.Movimento.Where(u => u.Id.Equals(id)).SingleOrDefault();
        }

       
    }
}
