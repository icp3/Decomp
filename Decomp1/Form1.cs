using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Decomp1
{
    public partial class Form1 : Form
    {
        readonly List<Files> items;

        readonly TabControl Tabby;

        public Form1(string[] Files)
        {

            this.Width = 800;
            this.Height = 800;


            items = new List<Files>();
            Tabby = new TabControl()
            {
                Height = this.Height,
                Width = this.Width,
            };

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




    }
}
