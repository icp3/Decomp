using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;


namespace Decomp1
{
    class FunctionButton : TabAction
    {

        public FunctionButton Cons
        {
            get { return Cons; }
            protected set { Cons = value; }
        }

        public FunctionButton(MethodInfo Value)
        {
            Data = Value;
            Arguments = new List<Argument>();

            Init = GetDefaultButton(Data.Name);

            var ReturnType = new Argument(Value.ReturnType.GetType());

            foreach (var Param in Data.GetParameters())
                Arguments.Add(new Argument(Param));

            foreach (var args in Arguments)
                Controls.Add(args);
        }

    }
}
