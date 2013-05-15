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

        public static string ToYesNo(this bool b)
        {
            return b ? "Yes" : "No";
        }
    }
}