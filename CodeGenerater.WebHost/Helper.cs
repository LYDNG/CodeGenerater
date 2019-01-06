using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeGenerater
{
    public class Helper
    {
        public static string getType(MyCodeGenerater.Core.Entity.ColumnEntity eneity)
        {
            return eneity.CSharpType;
        }
    
    }
}