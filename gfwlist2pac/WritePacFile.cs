using System;
using System.IO;
using System.Text;

namespace gfwlist2pac
{
    class WritePacFile
    {
        public static bool writePacFile(string pac)
        {
            try
            {
                File.WriteAllText("pac.txt", pac, Encoding.UTF8);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
