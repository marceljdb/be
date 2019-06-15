using be.business.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace be.business.Model
{
    public class Pulso
    {
        public PulsoStatus PulsoStatus { get; set; }

        public Boolean IsValid(PulsoStatus status)
        {
            return EnumUtils.EnumValidOrder<PulsoStatus>(PulsoStatus, (int)status);            
        }

    }

    public enum PulsoStatus
    {
        MINUS_90,
        MINUS_45,
        REPOUSO,
        MAJOR_45,
        MAJOR_90,
        MAJOR_135,
        MAJOR_180

    }
}
