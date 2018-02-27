using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace gfwlist2pac
{
    static class Program
    {
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Process[] proc = Process.GetProcessesByName("gfwlist2pac");
            if (proc.Length > 1)
            {
                MessageBox.Show("Program is already running.", "gfwlist2pac", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            DialogResult dialog = MessageBox.Show("Update to newest gfwlist,\r\nWill write \"pac.txt\" file here.",
                "gfwlist2pac", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)
            {
                string url = "https://raw.githubusercontent.com/gfwlist/gfwlist/master/gfwlist.txt";
                string raw = Network.network(url);
                if (raw == string.Empty)
                {
                    MessageBox.Show("Network error.", "gfwlist2pac", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                string text = Base64Text.Base64Decode(raw);
                string pac = Text2Pac.text2Pac(text);
                if (WritePacFile.writePacFile(pac))
                {
                    MessageBox.Show("Complete!", "gfwlist2pac", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Access authority error.", "gfwlist2pac", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
        }
    }
}
