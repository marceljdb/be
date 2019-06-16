using be.business.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace be.business.Model
{
    public class Cotovelo
    {
        [DisplayName("Cotovelo")]
        public CotoveloStatus CotoveloStatus { get; set; }

        public void IsValid(CotoveloStatus status)
        {
            if (CotoveloStatus != status)
            {
                IsValidOrder(status);                
            }           
        }

        
        public void IsValidOrder(CotoveloStatus status)
        {
            if (!EnumUtils.EnumValidOrder<CotoveloStatus>(CotoveloStatus, (int)status))
            {
                throw new Exception("Cotovelo indisponível. Movimento deve ser sequencial crescente/decrescente. Atual: " + status.ToString());
            }
        }

    }

    public enum CotoveloStatus
    {
        [Display(Name = "Repouso")]
        REPOUSO,
        [Display(Name = "Levemente Contraido")]
        LEVEMENTE_CONTRAIDO,
        [Display(Name = "Contraido")]
        CONTRAIDO,
        [Display(Name = "Fortemente Contraido")]
        FORTEMENTE_CONTRAIDO
    }
}
