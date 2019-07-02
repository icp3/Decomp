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

        public readonly List<Classe> NumOfClasses;

        public Files(string Filename)
        {
            Text = Filename.Substring(Filename.LastIndexOf('\\') + 1);
            asm = Assembly.LoadFile(Filename);
            NumOfClasses = new List<Classe>();

            foreach (var typ in asm.GetModules())
                NumOfClasses.Add(new Classe(typ));

            Height = 10;
        }
    }
}
