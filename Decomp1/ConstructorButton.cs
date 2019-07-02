using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;


namespace Decomp1
{
    class ConstructorButton : TabAction
    {
        public ConstructorButton(MethodInfo Value)
        {
            Data = Value;
            Arguments = new List<Argument>();

            Init = GetDefaultButton(Data.Name);

            foreach (var Param in Data.GetParameters())
            {
                Arguments.Add(new Argument(Param));
            }

        }
    }
}
