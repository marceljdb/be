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
           
        }

        public Movimento Pesquisar()
        {
            return MovimentoRepository.FindFirst();
        }


    }
}
