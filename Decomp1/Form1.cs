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

            this.Width = 800;
            this.Height = 800;


            items = new List<Files>();
            Tabby = new TabControl()
            {
                Height = this.Height,
                Width = this.Width,
            };
        
            string[] Files = InitialData();

            if (Files == null || Files.Length == 0)
            {
                this.Close();
                return;
            }

            InitializeComponent();

            foreach (string file in Files)
                items.Add(new Files(file));

            foreach (Files fi in items)
                fi.LoadCons();

            foreach (Files fi in items)
            {
                Tabby.Controls.Add(fi);
                fi.UpdateSelected();
            }

            Controls.Add(Tabby);

            Tabby.Update();

            this.Update();
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
