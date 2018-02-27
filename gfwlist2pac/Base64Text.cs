using System;
using System.Text;

namespace gfwlist2pac
{
    class Base64Text
    {
        public static string Base64Encode(Encoding encoding, string source)
        {
            string encode = string.Empty;
            byte[] bytes = encoding.GetBytes(source);
            try
            {
                encode = Convert.ToBase64String(bytes);
                return encode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return string.Empty;
            }

        }

        public static string Base64Encode(string source)
        {
            return Base64Encode(Encoding.UTF8, source);
        }

        public static string Base64Decode(Encoding encoding, string result)
        {
            string decode = string.Empty;
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encoding.GetString(bytes);
                return decode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return string.Empty;
            }
        }

        public static string Base64Decode(string result)
        {
            return Base64Decode(Encoding.UTF8, result);
        }
    }
}
