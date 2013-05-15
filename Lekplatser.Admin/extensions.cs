using System.Globalization;

namespace Lekplatser.Admin
{
    public static class Extensions
    {
        public static string ToJsString(this float f)
        {
            var x = new NumberFormatInfo {NumberDecimalSeparator = "."};
            return f.ToString(x);
        }
    }
}