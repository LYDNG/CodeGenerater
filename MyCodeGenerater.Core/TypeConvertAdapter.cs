namespace MyCodeGenerater.Core
{
    using System;

    public class TypeConvertAdapter
    {
        private static ITypeConvertor m_Convertor = null;

        public static ITypeConvertor Convertor
        {
            get
            {
                if (m_Convertor == null)
                {
                    m_Convertor = new DefaultTypeConvertor();
                }
                return m_Convertor;
            }
            set
            {
                m_Convertor = value;
            }
        }
    }
}

