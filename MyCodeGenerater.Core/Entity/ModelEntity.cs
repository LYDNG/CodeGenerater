namespace MyCodeGenerater.Core.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ModelEntity
    {
        public string ConnectionString { get; set; }

        public List<string> TableNames { get; set; }
    }
}

