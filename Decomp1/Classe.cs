using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System;


namespace Decomp1
{
    class Classe
    {
        public readonly List<Class> Classes;

        public Classe(Module Value)
        {
            Classes = new List<Class>();

            Type[] types = Value.GetTypes();

            foreach (var Cla in types)
            {
                Classes.Add(new Class(Cla));
            }
        }
    }
}
