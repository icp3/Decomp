using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;


namespace Decomp1
{


    class Files : TabPage
    {

        public readonly Assembly Asm;

        public List<Class> NumOfClasses;

        public Files(string filename)
        {
            Asm = Assembly.LoadFile(filename);
            NumOfClasses = new List<Class>();

            foreach (var typ in Asm.GetTypes())
                NumOfClasses.Add(new Class(typ));

            foreach (var cla in NumOfClasses)
            {
                Height += cla.Height;
                if (cla.Width > Width)
                    Width = cla.Width;
            }

        }
    }
}
