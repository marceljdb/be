using be.business.Model;
using be.business.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be.business.Repository
{
    public class MovimentoRepository : RepositoryBase<Mov>
    {
        public override IQueryable<Mov> FindAll()
        {
            return BeModel.Movimento;
        }

        public Mov FindFirst()
        {
            return BeModel.Movimento.FirstOrDefault();
        }

       
    }
}
