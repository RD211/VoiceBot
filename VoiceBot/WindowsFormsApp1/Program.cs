using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Text;
namespace WindowsFormsApp1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            bool exists = false;
            if (File.Exists(Directory.GetCurrentDirectory() + @"\commands.txt"))
            {
                exists = true;
            }

            if (exists == false)
            {
                string t = VoiceBOT.Properties.Resources.command;
                FileStream fs = File.Create("commands.txt");
                fs.Close();
                File.WriteAllText("commands.txt", t);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Bot());
        }
    }
}
