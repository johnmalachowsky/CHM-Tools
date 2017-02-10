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
    public partial class SingleMultiLineInputForm : Form
    {
        public String Result;
        public bool Saved;

        public SingleMultiLineInputForm(string FormTitle, string LabelInfo, string TextboxDefault)
        {
            InitializeComponent();
            this.Text = FormTitle;
            label1.Text = LabelInfo;
            textBox1.Lines = TextboxDefault.Split(new Char [] {'\n', '\r'},StringSplitOptions.RemoveEmptyEntries);
            textBox1.Visible = true;
            textBox1.Focus();
    
        
        }


        private void Save_Click(object sender, EventArgs e)
        {
            Result=textBox1.Text;
            Saved = true;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Saved = false;
            Close();

        }

        private void SingleMultiLineInputForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string [] S=textBox1.Lines;
            Array.Sort(S);
            textBox1.Lines = S;
            
        }




    }
}
