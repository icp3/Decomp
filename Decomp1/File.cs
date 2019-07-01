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
            Text = asm.Location.Substring(asm.Location.LastIndexOf('\\') + 1),
            Height = 10,
            asm = Assembly.LoadFile(Filename);
            TabPage tab = TabpageLayout();
            Classes = new List<Classe>();

            foreach (var typ in asm.GetModules())
                Classes.Add(new Classe(typ));
        }



        public void LoadButs()
        {
            foreach(var cla in Classes)
                cla.LoadBut(ref this);
        }


        public TabPage LoadCons()
        {
            foreach (var cla in Classes)
                cla.LoadCons(ref tab);
        }

        public TabPage LoadFunc()
        {
            foreach (var cla in Classes)
                cla.LoadFunc(ref tab);
        }
    }
}
