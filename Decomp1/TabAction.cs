using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

namespace Decomp1
{

    class TabAction : Module
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


        protected virtual Label GetDefaultLabel(string Name)
        {
            return new Label
            {
                Height = 10,
                Text = Name,
            };
        }

        protected virtual Button GetDefaultButton(string Name)
        {
            return new Button
            {
                Height = 10,
                Text = Name,
            };
        }

        protected virtual List<Control> GetLabel() {
            return new List<Control> { Init };
        }

        public virtual void Load(ref TabPage Tabby, int y)
        {
            int x = 0;

            foreach(var lab in GetLabel())
            {
                lab.Location = new Point(x, y);
                Tabby.Controls.Add(lab);
                x += lab.Width;
            }
        }
    }
}
