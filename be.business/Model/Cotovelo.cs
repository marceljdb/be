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

        public Boolean IsValid(CotoveloStatus status)
        {
            EnumUtils.EnumValidOrder<CotoveloStatus>(CotoveloStatus, (int) status);
            return CotoveloStatus.Equals(CotoveloStatus.FORTEMENTE_CONTRAIDO);
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
