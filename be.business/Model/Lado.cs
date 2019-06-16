using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace be.business.Model
{
    public enum Lado
    {
        [Display(Name = "Esquerdo")]
        ESQUERDO,
        [Display(Name = "Direito")]
        DIREITO
    }
}
