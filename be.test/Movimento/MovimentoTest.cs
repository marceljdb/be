using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using be.business.Model;
using be.business.Utils;

namespace be.test.MovimentoTest
{
    [TestClass]
    public class MovimentoTest
    {
        //•	O estado inicial dos movimentos é Em Repouso.
        //•	Só poderá movimentar o Pulso caso o Cotovelo esteja Fortemente Contraído.
        //•	Só poderá Rotacionar a Cabeça caso sua Inclinação da Cabeça não esteja em estado Para Baixo. 
        //•	Ao realizar a progressão de estados, é necessário que sempre siga a ordem crescente ou decrescente, por exemplo, a partir do estado 4, pode-se ir para os estados 3 ou 5, nunca pulando um estado.
        //•	Atenção aos limites! Se tentar enviar um estado inválido você irá corromper o sistema do R.O.B.O.
        private Movimento movimento;

        public MovimentoTest()
        {
            movimento = JsonConvert.DeserializeObject<Movimento>(File.ReadAllText(@".\\Resources\corpo.json"));
        }

        [TestMethod]
        public void IsValidMovimentarPulsoEsquerdo()
        {         
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
            Assert.IsTrue(movimento.Cabeca.IsValid());
        }

        [TestMethod]
        public void isValidMovimentacao()
        {
            var braco = (movimento.Bracos.Find(u => u.Lado.Equals(Lado.DIREITO)));
            Assert.IsTrue(EnumUtils.EnumValidOrder<CotoveloStatus>(braco.Cotovelo.CotoveloStatus, (int)CotoveloStatus.LEVEMENTE_CONTRAIDO));
        }



        private void MovimentarPulso(Lado lado)
        {
            var pulso = (movimento.Bracos.Find(u => u.Lado.Equals(lado)));
            Assert.IsNotNull(pulso);
            Assert.IsNotNull(pulso.Cotovelo);
            Assert.IsTrue(pulso.Cotovelo.IsValid(CotoveloStatus.REPOUSO));
        }
    }
}
