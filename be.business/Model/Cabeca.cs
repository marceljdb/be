using be.business.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace be.business.Model
{
    public class Cabeca
    {
        //Anotation enum valid order
        [DisplayName("Rotação")]
        public RotacaoStatus RotacaoStatus { get; set; }

        [DisplayName("Inclinação")]
        public InclinacaoStatus InclinacaoStatus { get; set; } 

        public Boolean IsValid(RotacaoStatus rotacaoStatus)
        {
            return (rotacaoStatus != RotacaoStatus) &&
            !InclinacaoStatus.Equals(InclinacaoStatus.BAIXO);
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
        [Display(Name = "-90 Graus")]
        MINUS_90,
        [Display(Name = "-45 Graus")]
        MINUS_45,
        [Display(Name = "Repouso")]
        REPOUSO,
        [Display(Name = "45 Graus")]
        MAJOR_45,
        [Display(Name = "90 Graus")]
        MAJOR_90
    }

    public enum InclinacaoStatus
    {
        [Display(Name = "Cima")]
        CIMA,
        [Display(Name = "Repouso")]
        REPOUSO,
        [Display(Name = "Baixo")]
        BAIXO
    }
}
