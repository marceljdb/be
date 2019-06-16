using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.business.Utils
{
    public class ValidOrder : ValidationAttribute
    {
        public int Status { get; set; }
        public int Limit { get; set; }

        public ValidOrder(int status, int limit)
        {
            this.Status = status;
            this.Limit = limit;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;            
            return EnumUtils.EnumValidOrder<int>((int) value, this.Status, this.Limit);
        }
    }
}
