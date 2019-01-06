namespace MyCodeGenerater.Core
{
    using System;

    public interface ITypeConvertor
    {
        string ToCSharp(string DBType, string dataScale);
    }
}

