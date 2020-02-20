using System;

namespace program
{
    public static class StringExtension
    {
        public static int ToInt(this string s)
        {
            return Int32.Parse(s);
        }
    }
}