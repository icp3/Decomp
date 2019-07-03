using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace Decomp1
{

    class TabAction : GroupBox
    {
        public MethodInfo Data;

        public List<Argument> Arguments;

        public Button Init;
        
        public TabAction() { }

        public TabAction(MethodInfo value)
        {
            Data = value;

            Arguments = new List<Argument>();

            Init = GetDefaultButton(Data.Name);

        }

        protected static TextBox GetDefaultTextBox(string name, int x = 10, int y = 10)
        {
            return new TextBox
            {
                Height = y,
                Text = name,
                Name = name,
                Width = x,
                Visible = true,
            };
        }

        protected static RadioButton GetDefaultRadioButton(string name, int y = 10)
        {
            return new RadioButton{
                Height = y,
                Text = name,
                Name = name,
                Visible = true,
            };
        }


        protected static Label GetDefaultLabel(string name, int y = 10)
        {
            return new Label
            {
                Height = y,
                Text = name,
                Name = name,
                Visible = true,
            };
        }

        protected static Button GetDefaultButton(string name, int y = 10)
        {
            return new Button
            {
                Height = 10,
                Text = name,
                Name = name,
                Visible = true,
            };
        }
    }
}
