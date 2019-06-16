using be.business.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace be.client.Models
{
    public class HomeViewModel
    {
        [DisplayName("Rotação")]
        public RotacaoStatus RotacaoStatus { get; set; }

        [DisplayName("Inclinação")]
        public InclinacaoStatus InclinacaoStatus { get; set; }

        public Lado Lado { get; set; }

        [DisplayName("Cotovelo")]
        public CotoveloStatus CotoveloStatus { get; set; }

        [DisplayName("Pulso")]
        public PulsoStatus PulsoStatus { get; set; }
    }
}