using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Helpers
{
    public static class NullableTypesHelper
    {
        public static bool TryParseBool(bool? value)
        {
            if (value == null)
                return false;

            return (bool)value;
        }

        public static int? TryParseInt(string val)
        {
            int outValue;
            return int.TryParse(val, out outValue) ? (int?)outValue : null;
        }
    }
}
