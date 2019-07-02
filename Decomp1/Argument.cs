using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Decomp1
{

    class Argument : TabAction
    {

        private readonly ParameterInfo Param;

        readonly List<RadioButton> Radior;

        readonly TextBox TextBoxy;


        public Argument(ParameterInfo Value)
        {
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
                            TextBoxy = GetDefaultTextBox(Param.DefaultValue.ToString());
                        else
                            TextBoxy = GetDefaultTextBox("0");
                    }
                    else if (Param.ParameterType == character.GetType())
                    {
                        if (Param.HasDefaultValue == true)
                            TextBoxy = GetDefaultTextBox(Param.DefaultValue.ToString(), 1);
                        else
                            TextBoxy = GetDefaultTextBox("C");
                    }
                    else if (Param.ParameterType == chararray.GetType())
                    {
                        if (Param.HasDefaultValue == true)
                            TextBoxy = GetDefaultTextBox(Param.DefaultValue.ToString());
                        else
                            TextBoxy = GetDefaultTextBox("CharString");
                    }
                    else if (Param.ParameterType == stringvar.GetType())
                    {
                        if (Param.HasDefaultValue == true)
                            TextBoxy = GetDefaultTextBox(Param.DefaultValue.ToString());
                        else
                            TextBoxy = GetDefaultTextBox("String");
                    }
                    else if (Param.ParameterType == DoublePrecision.GetType() || Param.ParameterType == SinglePrecision.GetType())
                    {
                        if (Param.HasDefaultValue == true)
                            TextBoxy = GetDefaultTextBox(Param.DefaultValue.ToString());
                        else
                            TextBoxy = GetDefaultTextBox("0.0");
                    }
                    else
                    {
                        Controls.Add(GetDefaultLabel(Param.ParameterType.ToString()));
                        return;
                    }
                    Controls.Add(TextBoxy);
                }
            }
            else {
                Controls.Add(GetDefaultLabel(Param.ParameterType.ToString()));
            }
        }

        public Argument(System.Type type)
        {
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
                        TextBoxy = GetDefaultTextBox("0");
                    else if (type == character.GetType())
                        TextBoxy = GetDefaultTextBox("C");
                    else if (Param.ParameterType == chararray.GetType())
                        TextBoxy = GetDefaultTextBox("CharString");
                    else if (Param.ParameterType == stringvar.GetType())
                        TextBoxy = GetDefaultTextBox("String");
                    else if (Param.ParameterType == DoublePrecision.GetType() || Param.ParameterType == SinglePrecision.GetType())
                        TextBoxy = GetDefaultTextBox("0.0");
                    else
                    {
                        Controls.Add(GetDefaultLabel(Param.ParameterType.ToString()));
                        return;
                    }
                    Controls.Add(TextBoxy);
                }
            }
            else
            {
                Controls.Add(GetDefaultLabel(Param.ParameterType.ToString()));
            }
        }
    }
}
