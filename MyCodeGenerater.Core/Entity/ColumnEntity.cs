namespace MyCodeGenerater.Core.Entity
{
    using MyCodeGenerater.Core;
    using System;
    using System.Runtime.CompilerServices;

    public class ColumnEntity
    {
        public string Comments { get; set; }

        public string NullAble { get; set; }
        public int? Length { get; set; }

        public string CSharpType
        {
            get
            {
                return TypeConvertAdapter.Convertor.ToCSharp(this.DBType,this.DataScale);
            }
        }
        public string CSharpPascalType
        {
            get
            {
                return ExtendHelper.PascalNameFormat(CSharpType);
            }
        }
        

        public string DBType { get; set; }

        public string Name { get; set; }

        public string DataScale { get; set; }

        public string PascalName
        {
            get
            {
                return ExtendHelper.PascalNameFormat(Name);
            }
        }
    }
}

