using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Decomp1
{

    class Argument : TabAction
    {
        enum TypeEnum
        {
            Double,
            Integer,
            String,
            CharString,
            Char,
            Bool,
            Null,
        }
        private readonly ParameterInfo Param;

        private readonly Label Namer;

        readonly List<RadioButton> Radior;

        readonly TextBox TextBoxy;

        readonly TypeEnum what;

        public Argument(ParameterInfo Value)
        {
            Namer = new Label();
            Radior = new List<RadioButton>();
            TextBoxy = new TextBox();
            what = new TypeEnum();
            Param = Value;
            if (Param.ParameterType.IsValueType == true)
            {
                int integer = 0;
                if (Param.ParameterType == integer.GetType())
                    what = TypeEnum.Integer;
                char character = '0';
                if (Param.ParameterType == character.GetType())
                    what = TypeEnum.Char;
                char[] chararray = { '0' };
                if (Param.ParameterType == chararray.GetType())
                    what = TypeEnum.CharString;
                string stringvar = "";
                if (Param.ParameterType == stringvar.GetType())
                    what = TypeEnum.String;
                double DoublePrecision = 0.0;
                float SinglePrecision = 0.0F;
                if (Param.ParameterType == DoublePrecision.GetType() || Param.ParameterType == SinglePrecision.GetType())
                    what = TypeEnum.Double;
                bool Boolean = true;
                if (Param.ParameterType == Boolean.GetType())
                    what = TypeEnum.Bool;
            }
            else
                what = TypeEnum.Null;

            CreateLayout();
        }

        void CreateLayout()
        {
            Namer.Text = Param.Name;
            switch (what)
            {
                case TypeEnum.Double:
                    if (Param.HasDefaultValue == true)
                        TextBoxy.Text = Param.DefaultValue.ToString();
                    else
                        TextBoxy.Text = "0.0";
                    break;
                case TypeEnum.Integer:
                    if (Param.HasDefaultValue == true)
                        TextBoxy.Text = Param.DefaultValue.ToString();
                    else
                        TextBoxy.Text = "0";
                    break;
                case TypeEnum.String:
                    if (Param.HasDefaultValue == true)
                        TextBoxy.Text = Param.DefaultValue.ToString();
                    else
                        TextBoxy.Text = "String";
                    break;
                case TypeEnum.CharString:
                    if (Param.HasDefaultValue == true)
                        TextBoxy.Text = Param.DefaultValue.ToString();
                    else
                        TextBoxy.Text = "CharString";
                    break;
                case TypeEnum.Char:
                    if (Param.HasDefaultValue == true)
                        TextBoxy.Text = Param.DefaultValue.ToString();
                    else
                        TextBoxy.Text = "C";
                    break;
                case TypeEnum.Bool:
                    Radior.Add(new RadioButton());
                    Radior[0].Name = "True";
                    Radior.Add(new RadioButton());
                    Radior[1].Name = "False";
                    break;
                case TypeEnum.Null:
                    break;
            }
        }

        public List<Control> Load()
        {
            List<Control> ret = new List<Control>();
            switch (what)
            {
                default:
                    ret.Add(Namer);
                    ret.Add(TextBoxy);
                    break;
                case TypeEnum.Bool:
                    ret.Add(Namer);
                    ret.AddRange(Radior);
                    break;
            }
            return ret;
        }
    }
}
