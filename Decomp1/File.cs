using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace Decomp1
{


    class Files : TabPage
    {

        readonly Assembly asm;

        readonly List<Classe> Classes;

        public Files(string Filename)
        {
            Text = Filename.Substring(Filename.LastIndexOf('\\') + 1);
            Height = 10;
            asm = Assembly.LoadFile(Filename);
            Classes = new List<Classe>();

            foreach (var typ in asm.GetModules())
                Classes.Add(new Classe(typ));
        }

        public void LoadButs()
        {
            foreach (var cla in Classes)
            {
                cla.LoadButs();
                Controls.Add(cla);
            }
        }


        public void LoadCons(int y = 10)
        {
            foreach (var cla in Classes)
            {
                cla.LoadCons(ref y);
                Controls.Add(cla);
            }
        }

        public void LoadFunc(int y = 10)
        {
            foreach (var cla in Classes)
            {
                cla.LoadFunc(ref y);
                Controls.Add(cla);
            }
            
        }

        public void UpdateSelected()
        {
            this.Update();
        }
    }
}
