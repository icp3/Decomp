using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;


namespace Decomp1
{


    class Files : TabPage
    {

        public readonly Assembly Asm;

        public readonly List<Classe> NumOfClasses;

        public Files(string filename)
        {
            Asm = Assembly.LoadFile(filename);
            NumOfClasses = new List<Classe>();
            Height = 10;

            foreach (var typ in Asm.GetModules())
                NumOfClasses.Add(new Classe(typ));

        }
    }
}
