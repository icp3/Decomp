using System.Collections.Generic;
using System.Reflection;
using System.Runtime;
using System.Threading;

namespace Decomp1
{
    class Classe
    {
        public readonly List<Class> Classes;

        public Classe(Module value)
        {
            Classes = new List<Class>();

            foreach (var cla in value.GetTypes())
                Classes.Add(new Class(cla) {Text = cla.Name});
        }
    }
}
