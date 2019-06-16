using be.business.Model;
using be.business.Repository;
using be.kernel.CustomError;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace be.business.Facade
{
    public class MovimentoFacade
    {

        [Inject]
        public MovimentoRepository MovimentoRepository;

        public void Atualizar(Movimento movimento)
        {
            var mov = MovimentoRepository.FindById(movimento.Id);
            var a = JsonConvert.DeserializeObject<Movimento>(mov.Movimento);
            if (!movimento.Cabeca.IsValid(a.Cabeca.RotacaoStatus))
            {
                throw new Exception("Rotação indisponível. Inclinação com Situaçao para Baixo"); 
            }

            mov.Movimento = JsonConvert.SerializeObject(movimento);
            MovimentoRepository.UpdateAndFlush(mov);
        }


    }
}
