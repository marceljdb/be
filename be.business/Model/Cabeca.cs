using be.business.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace be.business.Model
{
    public class Cabeca
    {
        //Anotation enum valid order
        public RotacaoStatus RotacaoStatus { get; set; }
        public InclinacaoStatus InclinacaoStatus { get; set; } = InclinacaoStatus.REPOUSO;

        public Boolean IsValid()
        {
            return !InclinacaoStatus.Equals(InclinacaoStatus.BAIXO);
        }

        public Boolean IsValidOrderRotacao(RotacaoStatus status)
        {
            return EnumUtils.EnumValidOrder<RotacaoStatus>(RotacaoStatus, (int)status);
        }

        public Boolean IsValidOrderInclinacao(InclinacaoStatus status)
        {
            return EnumUtils.EnumValidOrder<InclinacaoStatus>(InclinacaoStatus, (int)status);
        }

    }

    public enum RotacaoStatus
    {
        MINUS_90,
        MINUS_45,
        REPOUSO,
        MAJOR_45,
        MAJOR_90
    }

    public enum InclinacaoStatus
    {
        CIMA,
        REPOUSO,
        BAIXO
    }
}
