using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;


namespace Decomp1
{
    class Classe : GroupBox
    {
        readonly List<ConstructorButton> Cons;

        readonly List<FunctionButton> Func;

        readonly List<TabAction> Priv;

        public Classe(Module Value)
        {
            Cons = new List<ConstructorButton>();
            Func = new List<FunctionButton>();
            Priv = new List<TabAction>();

            foreach (var Meth in Value.GetMethods())
            {
                if (Meth.IsConstructor == true)
                    Cons.Add(new ConstructorButton(Meth));
                else if (Meth.IsPublic == true)
                    Func.Add(new FunctionButton(Meth));
                else
                    Priv.Add(new TabAction(Meth));
            }
            Height = (Cons.Count + Func.Count + Priv.Count) * 10;
            Text = Value.Name;
        }

        public Classe LoadButs( int y = 0, int y_default = 10)
        {
            LoadCons(ref y, y_default);
            LoadFunc(ref y, y_default);
            return this;
        }

        public Classe LoadCons(ref int y, int y_default = 10)
        {
            if( y == 0)
                Controls.Clear();
            foreach (var cons in Cons)
            {
                Controls.Add(cons);
                y += y_default;
            }
            return this;
        }

        public Classe LoadFunc(ref int y, int y_default = 10)
        {
            if (y == 0)
                Controls.Clear();
            foreach (var func in Func)
            {
                func.Load( y);
                y += y_default;
            }
            return this;
        }
    }
}
