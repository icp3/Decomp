using System;
using System.Windows.Forms;
using System.Runtime;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace Decomp1
{
    class Program
    {
        static string[] InitialData()
        {
            OpenFileDialog dia = new OpenFileDialog()
            {
                Filter = "Exe Files(*.exe)|*.exe|DLL Files(*.dll)|*.dll",
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
            string[] files = InitialData();

            if (files == null || files.Length == 0)
            {
                return;
            }
            Application.EnableVisualStyles();
            var form = new Form1(files) {Name = "Decomp"};
            Application.Run(form);
        }
    }
}
