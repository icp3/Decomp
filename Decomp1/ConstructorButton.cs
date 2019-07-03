using System.Collections.Generic;
using System.Reflection;


namespace Decomp1
{
    class ConstructorButton : TabAction
    {
        public ConstructorButton(MethodInfo value)
        {
            Data = value;
            Arguments = new List<Argument>();

            Init = GetDefaultButton(Data.Name);

            foreach (var param in Data.GetParameters())
                Arguments.Add(new Argument(param));

        }
    }
}
