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
        public readonly List<Argument> RetType;

        public FunctionButton Cons
        {
            get { return Cons; }
            protected set { Cons = value; }
        }

        public FunctionButton(MethodInfo Value)
        {
            Name = Value.Name;
            Text = Value.Name;

            RetType = new List<Argument>();

            Data = Value;
            Arguments = new List<Argument>();

            Init = new Button
            {
                Height = 10,
                Text = Data.Name,
                Name = Data.Name,
                Visible = true,
            };

            RetType.Add(new Argument(Value.ReturnType));

            foreach (var Param in Data.GetParameters())
                Arguments.Add(new Argument(Param));

            Width = (RetType.Count * Default_Width) + Default_Width + (Arguments.Count * Default_Width);
        }

    }
}
