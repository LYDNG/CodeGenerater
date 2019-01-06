namespace MyCodeGenerater.Core.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class TableEntity
    {
        public List<ColumnEntity> Columns { get; set; }

        public string Comments { get; set; }

        public string Name { get; set; }
        public string PascalName
        {
            get
            {
                return ExtendHelper.PascalNameFormat(Name);
            }
        }
    }
}

