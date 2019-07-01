using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Decomp1
{
    public partial class Form1 : Form
    {
        readonly List<Files> items;


        readonly TabControl Tabby;

        public Form1()
        {
            
            items = new List<Files>();
            Tabby = new TabControl();
            string[] Files = InitialData();

            if (Files == null || Files.Length == 0)
            {
                this.Close();
                return;
            }

            foreach (string file in Files)
            {
                items.Add(new Files(file));
            }

            foreach(Files fi in items)
            {
                Tabby.Controls.Add(fi.LoadCons());
            }
            Controls.Add(Tabby);

            InitializeComponent();
        }

        private string[] InitialData()
        {
            OpenFileDialog dia = new OpenFileDialog() {
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

    }
}
