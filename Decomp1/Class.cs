using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace Decomp1
{

    class Class : GroupBox
    {
        public  List<ConstructorButton> Cons;
        public  List<FunctionButton> Func;
        public  List<TabAction> Priv;

        public Class(Type type)
        {
            Cons = new List<ConstructorButton>();
            Func = new List<FunctionButton>();
            Priv = new List<TabAction>();

            Text = type.Name;
            Name = type.Name;

            Height = 0;

            foreach (MethodInfo meth in type.GetMethods())
            {
                if (meth.IsConstructor == true)
                    Cons.Add(new ConstructorButton(meth));
                else if (meth.IsPrivate == true)
                    Priv.Add(new TabAction(meth));
                else
                    Func.Add(new FunctionButton(meth));
                Height += 20;
            }

            foreach (var func in Func)
                if (func.Width > Width)
                    Width = func.Width;
        }
    }
}
