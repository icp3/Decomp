using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Decomp1
{
    public partial class Form1 : Form
    {
        readonly List<Files> items;

        readonly TabControl Tabby;

        public Form1(string[] Files)
        {
            this.Width = 800;
            this.Height = 800;


            items = new List<Files>();
            Tabby = new TabControl()
            {
                Height = this.Height,
                Width = this.Width,
            };

            Controls.Add(Tabby);

            //Tabby.Controls.Add(new TabPage { Text = "test" });

            foreach (string file in Files)
                items.Add(new Files(file));

            int y_default = 20;
            int x_default = 30;
            foreach (Files fi in items){
                int Initial_location = 0;
                foreach (var file in fi.NumOfClasses)
                {
                    
                    foreach (var Cla in file.Classes)
                    {
                        Cla.Location = new Point(0, Initial_location);
                        int Class_Height = 0;

                        foreach(var ClaFunc in Cla.Func)
                        {
                            Class_Height += y_default;
                            ClaFunc.Location = new Point(0, Initial_location + Class_Height);
                            int width = 0;

                            foreach (var ret in ClaFunc.RetType)
                            {
                                ret.Location = new Point(width, Initial_location + Class_Height + y_default);
                                ret.Visible = true;
                                ret.Height = y_default;
                                ClaFunc.Controls.Add(ret);
                                width += x_default;
                            }

                            ClaFunc.Init.Height = 10;
                            ClaFunc.Init.Visible = true;
                            ClaFunc.Init.Location= new Point(width,Initial_location + Class_Height + y_default);
                            ClaFunc.Controls.Add(ClaFunc.Init);
                            foreach (var args in ClaFunc.Arguments)
                            {
                                args.Location = new Point(0, Initial_location + Class_Height);
                                foreach (var BoolArgs in args.Radior)
                                {
                                    BoolArgs.Location = new Point(width, Initial_location + Class_Height + y_default);
                                    BoolArgs.Visible = true;
                                    BoolArgs.Height = y_default;
                                    ClaFunc.Controls.Add(BoolArgs);
                                    width += x_default;
                                }
                                foreach (var TextArgs in args.TextBoxy)
                                {
                                    TextArgs.Location = new Point(width, Initial_location + Class_Height + y_default);
                                    TextArgs.Visible = true;
                                    TextArgs.Height = y_default;
                                    ClaFunc.Controls.Add(TextArgs);
                                    width += x_default;
                                }
                            }
                            Class_Height += y_default;
                            Cla.Controls.Add(ClaFunc);
                        }
                        Cla.Height = Class_Height;
                        Initial_location += Class_Height;
                        fi.Controls.Add(Cla);
                    }
                }
                fi.Height = Initial_location;
                Tabby.Controls.Add(fi);
            }



            InitializeComponent();
        }
    }
}
