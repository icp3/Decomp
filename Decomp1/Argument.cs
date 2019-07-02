using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Decomp1
{

    class Argument : TabAction
    {

        private readonly ParameterInfo Param;

        public readonly List<RadioButton> Radior;

        public readonly List<TextBox> TextBoxy;


        public Argument(ParameterInfo Value)
        {
            Radior = new List<RadioButton>();
            TextBoxy = new List<TextBox>();
            Param = Value;
            Text = Param.Name;
            if (Param.ParameterType.IsValueType == true)
            {
                bool Boolean = true;
                if (Param.ParameterType == Boolean.GetType())
                {
                    Radior = new List<RadioButton>();
                    Radior.Add(GetDefaultRadioButton("True"));
                    Radior.Add(GetDefaultRadioButton("False"));
                    foreach (var rad in Radior)
                        Controls.Add(rad);
                    return;
                }
                else
                {
                    int integer = 0;
                    char character = '0';
                    char[] chararray = { '0' };
                    string stringvar = "";

                    double DoublePrecision = 0.0;
                    float SinglePrecision = 0.0F;
                    if (Param.ParameterType == integer.GetType())
                    {
                        if (Param.HasDefaultValue == true)
                            TextBoxy.Add(GetDefaultTextBox(Param.DefaultValue.ToString()));
                        else
                            TextBoxy.Add(GetDefaultTextBox("0"));
                    }
                    else if (Param.ParameterType == character.GetType())
                    {
                        if (Param.HasDefaultValue == true)
                            TextBoxy.Add(GetDefaultTextBox(Param.DefaultValue.ToString(), 1));
                        else
                            TextBoxy.Add(GetDefaultTextBox("C"));
                    }
                    else if (Param.ParameterType == chararray.GetType())
                    {
                        if (Param.HasDefaultValue == true)
                            TextBoxy.Add(GetDefaultTextBox(Param.DefaultValue.ToString()));
                        else
                            TextBoxy.Add(GetDefaultTextBox("CharString"));
                    }
                    else if (Param.ParameterType == stringvar.GetType())
                    {
                        if (Param.HasDefaultValue == true)
                            TextBoxy.Add(GetDefaultTextBox(Param.DefaultValue.ToString()));
                        else
                            TextBoxy.Add(GetDefaultTextBox("String"));
                    }
                    else if (Param.ParameterType == DoublePrecision.GetType() || Param.ParameterType == SinglePrecision.GetType())
                    {
                        if (Param.HasDefaultValue == true)
                            TextBoxy.Add(GetDefaultTextBox(Param.DefaultValue.ToString()));
                        else
                            TextBoxy.Add(GetDefaultTextBox("0.0"));
                    }
                    else
                    {
                        Controls.Add(GetDefaultLabel(Param.ParameterType.ToString()));
                        return;
                    }
                    Controls.Add(TextBoxy[0]);
                }
            }
            else {
                Controls.Add(GetDefaultLabel(Param.ParameterType.ToString()));
            }
        }

        public Argument(Type type)
        {
            Radior = new List<RadioButton>();
            TextBoxy = new List<TextBox>();
            if (type.IsValueType == true)
            {
                bool Boolean = true;
                if (type == Boolean.GetType())
                {
                    Radior = new List<RadioButton>();
                    Radior.Add(GetDefaultRadioButton("True"));
                    Radior.Add(GetDefaultRadioButton("False"));
                    foreach (var rad in Radior)
                        Controls.Add(rad);
                    return;
                }
                else
                {

                    int integer = 0;
                    char character = '0';
                    char[] chararray = { '0' };
                    double DoublePrecision = 0.0;
                    float SinglePrecision = 0.0F;
                    string stringvar = "";

                    if (type == integer.GetType())
                        TextBoxy.Add(GetDefaultTextBox("0"));
                    else if (type == character.GetType())
                        TextBoxy.Add(GetDefaultTextBox("C"));
                    else if (type == chararray.GetType())
                        TextBoxy.Add(GetDefaultTextBox("CharString"));
                    else if (type == stringvar.GetType())
                        TextBoxy.Add(GetDefaultTextBox("String"));
                    else if (type == DoublePrecision.GetType() || type == SinglePrecision.GetType())
                        TextBoxy.Add(GetDefaultTextBox("0.0"));
                    else
                    {
                        Controls.Add(GetDefaultLabel("void"));
                        return;
                    }
                    Controls.Add(TextBoxy[0]);
                }
            }
            else
            {
                if(Param != null)
                    Controls.Add(GetDefaultLabel(Param.ToString()));
            }
        }
    }
}
