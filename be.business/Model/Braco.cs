using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace be.business.Model
{
    public class Braco
    {
        [DisplayName("Pulso")]
        public Pulso Pulso { get; set; }

        [DisplayName("Cotovelo")]
        public Cotovelo Cotovelo { get; set; }

        public Lado Lado { get; set; }

        public void IsValid(Braco braco)
        {
            Pulso.IsValid(braco.Pulso.PulsoStatus, braco.Cotovelo.CotoveloStatus);
            Cotovelo.IsValid(braco.Cotovelo.CotoveloStatus);
        }
    }
}
