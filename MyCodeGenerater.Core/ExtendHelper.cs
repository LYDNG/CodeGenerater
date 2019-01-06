namespace MyCodeGenerater.Core
{
    using System;
    using System.Runtime.CompilerServices;

    public static class ExtendHelper
    {
        public static string NameFormat(this string name, IOutNameFormat format)
        {
            return format.Out(name);
        }

        public static string PascalNameFormat(this string name)
        {
            return new Pascal().Out(name);
        }

        public static string PascalNameFormat1(string name)
        {
            return new Pascal().Out(name);
        }
    }
}

