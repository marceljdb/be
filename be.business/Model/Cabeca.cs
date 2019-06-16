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

        public void IsValid(Cabeca cabeca)
        {
            IsValidOrderRotacao(cabeca.RotacaoStatus);
            IsValidOrderInclinacao(cabeca.InclinacaoStatus);
            if (cabeca.RotacaoStatus != RotacaoStatus) {  
                IsValidRotacao(cabeca.InclinacaoStatus);
            }
        }

        public void IsValidRotacao(InclinacaoStatus inclinacaoStatus)
        {
            if (inclinacaoStatus.Equals(InclinacaoStatus.BAIXO))
            {
                throw new Exception("Rotação indisponível. Inclinação com Situaçao para Baixo");
            };
        }

        public void IsValidOrderRotacao(RotacaoStatus status)
        {
            if (!EnumUtils.EnumValidOrder<RotacaoStatus>(RotacaoStatus, (int)status))
            {
                throw new Exception("Rotação indisponível. Movimento deve ser sequencial crescente/decrescente. Atual: " + RotacaoStatus.ToString());
            }
;
        }

        public void IsValidOrderInclinacao(InclinacaoStatus status)
        {
            if (!EnumUtils.EnumValidOrder<InclinacaoStatus>(InclinacaoStatus, (int)status))
            {
                throw new Exception("Inclinação indisponível. Movimento deve ser sequencial crescente/decrescente. Atual: " + InclinacaoStatus.ToString());
            }
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
