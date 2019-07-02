using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decomp1
{
    class Program
    {
        static string[] InitialData()
        {
            OpenFileDialog dia = new OpenFileDialog()
            {
                Filter = "DLL Files(*.dll)|*.dll|Exe Files(*.exe)|*.exe",
                InitialDirectory = @"c:\Users\" + Environment.UserName,
                Multiselect = true
            };

            if (dia.ShowDialog() == DialogResult.OK)
            {
                return dia.FileNames;
            }
            return null;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            string[] Files = Program.InitialData();

            if (Files == null || Files.Length == 0)
            {
                return;
            }
            Application.EnableVisualStyles();
            Form1 form = new Form1(Files) { Name = "Decomp", Text = "Decomp" };
            Application.Run(form);
        }


    }
}
