using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using be.business.Model;
using be.business.Utils;
using Ninject;
using be.business.Repository;

namespace be.test.MovimentoTest
{
    [TestClass]
    public class MovimentoTest : NinjectTest
    {
        //•	O estado inicial dos movimentos é Em Repouso.
        //•	Só poderá movimentar o Pulso caso o Cotovelo esteja Fortemente Contraído.
        //•	Só poderá Rotacionar a Cabeça caso sua Inclinação da Cabeça não esteja em estado Para Baixo. 
        //•	Ao realizar a progressão de estados, é necessário que sempre siga a ordem crescente ou decrescente, por exemplo, a partir do estado 4, pode-se ir para os estados 3 ou 5, nunca pulando um estado.
        //•	Atenção aos limites! Se tentar enviar um estado inválido você irá corromper o sistema do R.O.B.O.


        public override void RegisterServices()
        {
            Kernel.Bind<BeModel>().ToSelf();
        }

        [TestMethod]
        public void IsValidMovimentarPulsoEsquerdo()
        {
            var mov = Kernel.Get<MovimentoRepository>();
            MovimentarPulso(Lado.ESQUERDO);
        }

        [TestMethod]
        public void isValidMovimentarPulsoDireito()
        {
            MovimentarPulso(Lado.DIREITO);
        }

        [TestMethod]
        public void isValidRotacionarCabeca()
        {
            var MovimentoRepository = Kernel.Get<MovimentoRepository>();
            var movimento = MovimentoRepository.FindFirst();
            movimento.Cabeca.IsValid(new Cabeca() { InclinacaoStatus = InclinacaoStatus.CIMA, RotacaoStatus = RotacaoStatus.MAJOR_45 });
        }

        [TestMethod]
        public void isValidMovimentacaoCotovelo()
        {
            var MovimentoRepository = Kernel.Get<MovimentoRepository>();
            var movimento = MovimentoRepository.FindFirst();
            var braco = (movimento.Bracos.Find(u => u.Lado.Equals(Lado.DIREITO)));
            braco.Cotovelo.IsValid(CotoveloStatus.CONTRAIDO);
        }



        private void MovimentarPulso(Lado lado)
        {
            var MovimentoRepository = Kernel.Get<MovimentoRepository>();
            var movimento = MovimentoRepository.FindFirst();
            var pulso = (movimento.Bracos.Find(u => u.Lado.Equals(lado)));
            Assert.IsNotNull(pulso);
            Assert.IsNotNull(pulso.Cotovelo);
            pulso.Pulso.IsValid(PulsoStatus.MINUS_45, CotoveloStatus.FORTEMENTE_CONTRAIDO);
        }

    }
}
