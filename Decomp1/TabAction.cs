using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace Decomp1
{

    class TabAction : GroupBox
    {
        protected MethodInfo Data;

        protected List<Argument> Arguments;

        protected Button Init;

        public Module Mod
        {
            get { return Mod; }
            private set { Mod = value; }
        }

        public TabAction() { }

        public TabAction(MethodInfo Value)
        {
            Data = Value;

            Arguments = new List<Argument>();

            Init = GetDefaultButton(Data.Name);

        }

        protected virtual TextBox GetDefaultTextBox(string name, int x = 10, int y = 10)
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

        protected virtual RadioButton GetDefaultRadioButton(string name, int y = 10)
        {
            return new RadioButton{
                Height = y,
                Text = name,
                Name = name,
                Visible = true,
            };
        }


        protected virtual Label GetDefaultLabel(string name, int y = 10)
        {
            return new Label
            {
                Height = y,
                Text = name,
                Name = name,
                Visible = true,
            };
        }

        protected virtual Button GetDefaultButton(string name, int y = 10)
        {
            return new Button
            {
                Height = 10,
                Text = name,
                Name = name,
                Visible = true,
            };
        }

        protected virtual List<Control> GetLabel() {
            return new List<Control> { Init };
        }

        public virtual List<Control> Load( int y)
        {
            List<Control> ret = new List<Control>();
            int x = 0;

            foreach(var lab in GetLabel())
            {
                lab.Location = new Point(x, y);
                ret.Add(lab);
                x += lab.Width;
            }
            return ret;
        }
    }
}
