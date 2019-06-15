using be.business.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace be.business.Facade
{
    public class MovimentoFacade
    {

        [Inject]
        public MovimentoRepository MovimentoRepository;

        public void Execute()
        {
            
        }


    }
}
