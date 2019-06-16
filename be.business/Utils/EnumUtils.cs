using System;
using System.Collections.Generic;
using System.Text;

namespace be.business.Utils
{
    public static class EnumUtils
    {
        public const int DEFAULT_LIMIT = 1;

        public static Boolean EnumValidOrder<TValue>(this TValue tvalue,int status, int limit = DEFAULT_LIMIT) where TValue : struct, IConvertible
        {
            int value = (int)(object)tvalue;
            return ((status == value) ||
                  ((status == value - limit) || (status == value + limit)));
        }

    }


}
