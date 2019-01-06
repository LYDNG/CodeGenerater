namespace MyCodeGenerater.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class DefaultTypeConvertor : ITypeConvertor
    {
        public virtual string CHAR(string DBType, string dataScale="")
        {
            return "string";
        }

        public virtual string DATE(string DBType, string dataScale = "")
        {
            return "DateTime";
        }

        public virtual string NUMBER(string DBType, string dataScale = "")
        {
            int scale = 0;
            int.TryParse(dataScale, out scale);
            if (scale > 0)
            {
                return "decimal";
            }
            return "long";
        }

        protected virtual string OtherCheck(string DBType, string dataScale = "")
        {
            if (DBType.Contains("TIMESTAMP"))
            {
                return "DateTime";
            }
            return DBType;
        }

        public virtual string ToCSharp(string DBType, string dataScale = "")
        {
            MethodInfo info = base.GetType().GetMethods().FirstOrDefault<MethodInfo>(it => it.Name == DBType);
            if (info != null)
            {
                return info.Invoke(this, new object[] { DBType, dataScale }).ToString();
            }
            return this.OtherCheck(DBType, dataScale);
        }

        public virtual string VARCHAR(string DBType, string dataScale = "")
        {
            return "string";
        }

        public virtual string VARCHAR2(string DBType, string dataScale = "")
        {
            return "string";
        }

        public virtual string NVARCHAR2(string DBType, string dataScale = "")
        {
            return "string";
        }
    }

}

