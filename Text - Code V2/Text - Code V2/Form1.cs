using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text___Code_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Translate_Click(object sender, EventArgs e)
        {
            Text___Code_V2.Text_To_Code.Invalid = false;
            Text___Code_V2.Code_To_Text.Invalid = false;
            switch (Input.Text)
            {
                case "Text to Code":
                    Text___Code_V2.Text_To_Code.Convert(InputBox.Text);
                    break;
                case "Code to Text":
                    Text___Code_V2.Code_To_Text.Convert(InputBox.Text);
                    break;
                default:
                    OutputBox.Text = "*Invalid Mode Selection*";
                    break;
            }
        }

        private void Input_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
