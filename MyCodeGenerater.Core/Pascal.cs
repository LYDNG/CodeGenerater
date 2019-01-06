namespace MyCodeGenerater.Core
{
    using System;
    using System.Text;

    public class Pascal : IOutNameFormat
    {
        public string Out(string name)
        {
            StringBuilder builder = new StringBuilder();
            string[] strArray = name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArray)
            {
                if (str.Length > 0)
                {
                    if (str.Length > 1)
                    {
                        builder.Append(str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower());
                    }
                    else
                    {
                        builder.Append(str.Substring(0, 1).ToUpper());
                    }
                }
            }
            var result = builder.ToString();
            if (result.EndsWith("id"))
            {
                result = result.Remove(result.Length - 3, 2)+"Id";
            }

            return result;
        }
    }
}

