﻿using System;
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
        readonly Label ReturnType;

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
            ReturnType = GetDefaultLabel(Value.ReturnType.ToString());
        

            foreach (var Param in Data.GetParameters())
            {
                Arguments.Add(new Argument(Param));
            }

        }

        protected override List<Control> GetLabel()
        {
            List<Control> ret = new List<Control> { ReturnType, Init};

            foreach (Argument Arg in Arguments)
            {
                ret.AddRange(Arg.Load());
            }

            return ret;
        }
    }
}
