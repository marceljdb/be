using be.business.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace be.business.Model
{
    public class Cotovelo
    {
        public CotoveloStatus CotoveloStatus { get; set; }

        public Boolean IsValid(CotoveloStatus status)
        {
            EnumUtils.EnumValidOrder<CotoveloStatus>(CotoveloStatus, (int) status);
            return CotoveloStatus.Equals(CotoveloStatus.FORTEMENTE_CONTRAIDO);
        }

    }

    public enum CotoveloStatus
    {
        REPOUSO,
        LEVEMENTE_CONTRAIDO,
        CONTRAIDO,
        FORTEMENTE_CONTRAIDO
    }
}
