using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Decomp1
{
    public partial class Form1 : Form
    {
        private List<Files> Data;

        TabControl Tabby;



        public Form1(string[] files)
        {
            Name = "Decomp";

            Data = new List<Files>();
            Tabby = new TabControl();

            Controls.Add(Tabby);

            //Tabby.Controls.Add(new TabPage { Text = "test" });

            foreach (string file in files)
                Data.Add(new Files(file){Text = file.Substring(file.LastIndexOf('\\') + 1)});

            foreach (var data in Data)
            {
                if (data.Width > Tabby.Width)
                    Tabby.Width = data.Width;
                Height += data.Height;
            }
            

            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            int y_default = 25;
            int x_default = 150;
            foreach (Files fi in Data)
            {
                int initiallocation = 0;
                foreach (var file in fi.NumOfClasses)
                {

                    file.Location = new Point(0, initiallocation);
                    int classHeight = 0;

                    foreach (var claFunc in file.Func)
                    {
                        classHeight += y_default;
                        claFunc.Location = new Point(0, initiallocation + classHeight);
                        int x = 0;

                        foreach (var ret in claFunc.RetType)
                        {
                            ret.Location = new Point(x, initiallocation + classHeight);
                            claFunc.Controls.Add(ret);
                            x += x_default;
                        }

                        claFunc.Init.Location = new Point(x, initiallocation + classHeight  );
                        claFunc.Controls.Add(claFunc.Init);
                        x += x_default;

                        foreach (var args in claFunc.Arguments)
                        {
                            args.Location = new Point(0, initiallocation + classHeight);
                            foreach (var boolArgs in args.Radior)
                            {
                                boolArgs.Location = new Point(x, initiallocation + classHeight );
                                claFunc.Controls.Add(boolArgs);
                                x += x_default;
                            }
                            foreach (var textArgs in args.TextBoxy)
                            {
                                textArgs.Location = new Point(x, initiallocation + classHeight );
                                claFunc.Controls.Add(textArgs);
                                x += x_default;
                            }
                        }
                        classHeight += y_default;
                        file.Controls.Add(claFunc);
                    }
                    file.Height = classHeight;
                    initiallocation += classHeight;                    
                }
                Tabby.Controls.Add(fi);
            }
        }
    }
}
