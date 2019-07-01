using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;


namespace Decomp1
{
    class Classe
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
        }

        public void LoadBut(ref TabPage Tabby, int y = 0)
        {
            LoadCons(ref Tabby, y);
            LoadFunc(ref Tabby, y);
        }

        public void LoadCons(ref TabPage Tabby, int y = 0)
        {
            foreach (var cons in Cons)
            {
                cons.Load(ref Tabby, y);
                y += 10;
            }
        }

        public void LoadFunc(ref TabPage Tabby, int y = 0)
        {
            foreach (var func in Func)
            {
                func.Load(ref Tabby, y);
                y += 10;
            }
        }
    }
}
