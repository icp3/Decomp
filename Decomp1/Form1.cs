using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Decomp1
{
    public partial class Form1 : Form
    {
        public Form1(string[] files)
        {
            Name = "Decomp";
            Width = 800;
            Height = 800;


            List<Files> data = new List<Files>();
            TabControl tabby = new TabControl();

            Controls.Add(tabby);

            //tabby.Controls.Add(new TabPage { Text = "test" });

            foreach (string file in files)
                data.Add(new Files(file){Text = file.Substring(file.LastIndexOf('\\') + 1)});

            int y_default = 20;
            int x_default = 30;

            foreach (Files fi in data){
                int initiallocation = 0;
                foreach (var file in fi.NumOfClasses)
                {
                    
                    foreach (var cla in file.Classes)
                    {
                        cla.Location = new Point(0, initiallocation);
                        int classHeight = 0;

                        foreach(var claFunc in cla.Func)
                        {
                            classHeight += y_default;
                            claFunc.Location = new Point(0, initiallocation + classHeight);
                            int width = 0;

                            foreach (var ret in claFunc.RetType)
                            {
                                ret.Location = new Point(width, initiallocation + classHeight + y_default);
                                claFunc.Controls.Add(ret);
                                width += x_default;
                            }

                            claFunc.Init.Location= new Point(width,initiallocation + classHeight + y_default);
                            claFunc.Controls.Add(claFunc.Init);
                            width += x_default;
                            foreach (var args in claFunc.Arguments)
                            {
                                args.Location = new Point(0, initiallocation + classHeight);
                                foreach (var boolArgs in args.Radior)
                                {
                                    boolArgs.Location = new Point(width, initiallocation + classHeight + y_default);
                                    claFunc.Controls.Add(boolArgs);
                                    width += x_default;
                                }
                                foreach (var textArgs in args.TextBoxy)
                                {
                                    textArgs.Location = new Point(width, initiallocation + classHeight + y_default);
                                    claFunc.Controls.Add(textArgs);
                                    width += x_default;
                                }
                            }
                            classHeight += y_default;
                            cla.Controls.Add(claFunc);
                        }
                        cla.Height = classHeight;
                        initiallocation += classHeight;
                        fi.Controls.Add(cla);
                    }
                }
                fi.Height = initiallocation;
                tabby.Controls.Add(fi);
            }
            InitializeComponent();
        }
    }
}
