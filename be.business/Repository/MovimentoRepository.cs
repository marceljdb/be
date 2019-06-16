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

        public Movimento FindById(int id)
        {
            var movimento = BeModel.Movimento.Where(u => u.Id.Equals(id)).SingleOrDefault();
            return JsonConvert.DeserializeObject<Movimento>(movimento.Movimento);
        }

        public MovimentoEntity FindEntityById(int id)
        {
            return BeModel.Movimento.Where(u => u.Id.Equals(id)).SingleOrDefault();
        }

        public void Update(Movimento movimento)
        {
            IsValid(movimento);
            var entity = FindEntityById(movimento.Id);
            entity.Movimento = JsonConvert.SerializeObject(movimento);
            UpdateAndFlush(entity);            
        }

        private void IsValid(Movimento movimento)
        {
            var mov = FindById(movimento.Id);
            mov.Cabeca.IsValid(movimento.Cabeca);
            foreach (var item in mov.Bracos)
            {
                var braco = movimento.Bracos.Find(u => u.Lado.Equals(item.Lado));
                item.IsValid(braco);
            }
        }

    }
}
