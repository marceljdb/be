using be.business.Model;
using be.business.Persistence;
using Newtonsoft.Json;
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

        public Movimento FindFirst()
        {
            var movimento = BeModel.Movimento.FirstOrDefault();
            return JsonConvert.DeserializeObject<Movimento>(movimento.Movimento);
        }

        public MovimentoEntity FindById(int id)
        {
            return BeModel.Movimento.Where(u => u.Id.Equals(id)).SingleOrDefault();
        }

       
    }
}
