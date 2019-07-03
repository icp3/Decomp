using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;


namespace Decomp1
{
    class ConstructorButton : TabAction
    {
        public ConstructorButton(MethodInfo value)
        {
            Data = value;
            Arguments = new List<Argument>();

            Init = new Button
            {
                Height = 20,
                Text = value.Name,
                Name = value.Name,
                Visible = true,
            };

            foreach (var param in Data.GetParameters())
                Arguments.Add(new Argument(param));

        }
    }
}
