using be.business.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace be.business.Model
{
    public class Pulso
    {
        [DisplayName("Pulso")]
        public PulsoStatus PulsoStatus { get; set; }

        public void IsValid(PulsoStatus status, CotoveloStatus cotoveloStatus)
        {
            if (status != PulsoStatus)
            {
                IsValidOrder(status);
                IsValidMovimento(cotoveloStatus);
            }
        }

        public void IsValidMovimento(CotoveloStatus status)
        {
            if (!status.Equals(CotoveloStatus.FORTEMENTE_CONTRAIDO)) {
                throw new Exception("Pulso indisponível. Cotovelo não está Fortemente Contraido.");
            }

        }

        public void IsValidOrder(PulsoStatus status)
        {
            if (!EnumUtils.EnumValidOrder<PulsoStatus>(PulsoStatus, (int)status))
            {
                throw new Exception("Pulso indisponível. Movimento deve ser sequencial crescente/decrescente. Atual: " + PulsoStatus.ToString());
            };
        }


    }

    public enum PulsoStatus
    {
        [Display(Name = "-90 Graus")]
        MINUS_90,
        [Display(Name = "-45 Graus")]
        MINUS_45,
        [Display(Name = "Repouso")]
        REPOUSO,
        [Display(Name = "45 Graus")]
        MAJOR_45,
        [Display(Name = "90 Graus")]
        MAJOR_90,
        [Display(Name = "135 Graus")]
        MAJOR_135,
        [Display(Name = "180 Graus")]
        MAJOR_180

    }
}
