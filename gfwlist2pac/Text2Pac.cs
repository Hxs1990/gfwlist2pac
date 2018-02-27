using System.Text.RegularExpressions;

namespace gfwlist2pac
{
    class Text2Pac
    {
        public static string text2Pac(string text)
        {
            string[] array = Regex.Split(text, "\n", RegexOptions.IgnoreCase);
            string temp = string.Empty;
            foreach (var line in array)
            {
                if (line == string.Empty || line.StartsWith("!") || line.StartsWith("[Auto")) { }
                else
                {
                    temp += "\t\"" + line + "\",\r\n";
                }
            }
            temp = temp.Substring(0, temp.Length - 3) + "\r\n";
            string pac = Properties.Resources.a + temp + Properties.Resources.b;
            return pac;
        }
    }
}
