using System;
using System.Collections.Generic;
using System.Text;

namespace be.business.Utils
{
    public static class EnumUtils
    {  

        public static Boolean EnumValidOrder<TValue>(this TValue tvalue, int status) where TValue : struct, IConvertible
        {
            int value = (int)(object)tvalue;
            return ((status == value) ||
                  ((status == value - 1) || (status == value + 1)));
        }

    }


}
