using System;

namespace Ensek.Web.API.Utility
{
    public static class Extensions
    {
        public static bool IsDigit(this string value, Int32 index)
        {
            return char.IsDigit(value, index);
        }

        public static bool IsDigit(this string value)
        {
            var result = true;
            for (int index = 0; index < value.Length; index++)
            {
                result = char.IsDigit(value, index);

                if (!result)
                    break;
            }

            return result;
        }
    }
}
