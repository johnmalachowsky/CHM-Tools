using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingTools
{
    public partial class SingleInputForm : Form
    {
        public String Result;
        public bool Saved;

        public SingleInputForm(string FormTitle, string LabelInfo, string TextboxDefault, string Mask)
        {
            InitializeComponent();
            this.Text = FormTitle;
            label1.Text = LabelInfo;
            if (!String.IsNullOrEmpty(Mask))
            {
                maskedTextBox1.Mask = Mask;
                maskedTextBox1.Text = TextboxDefault;
                textBox1.Visible = false;
                maskedTextBox1.Visible = true;
                maskedTextBox1.Focus();
            }
            else
            {
                textBox1.Text = TextboxDefault;
                textBox1.Visible = true;
                maskedTextBox1.Visible = false;
                textBox1.Focus();
            }
        
        }


        private void Save_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible == true)
                Result = textBox1.Text.Trim();
            else
                Result = maskedTextBox1.Text;

            Saved = true;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Saved = false;
            Close();

        }




    }
}
