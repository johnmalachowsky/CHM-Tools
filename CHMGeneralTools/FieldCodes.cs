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
    public partial class FieldCodes : Form
    {
        public string LocalFieldCode, LocalFieldCodeDescription;
        public bool LocalSave;
        int FieldNameIndex;
        
        public FieldCodes(string Title, String FCode, string Description, int index )
        {
            InitializeComponent();
            this.Text = this.Text + Title;
            FieldCode.Text = FCode;
            if (!string.IsNullOrEmpty(FCode))
                FieldCode.Enabled = false;
            FieldCodeDescription.Text = Description;
            LocalSave = false;
            FieldNameIndex = index;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            LocalSave = false;
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            LocalFieldCode = FieldCode.Text.Trim();
            LocalFieldCodeDescription = FieldCodeDescription.Text.Trim();
            if (FieldCode.Enabled)
            {
                for (int q = 0; q < DatabaseFieldsGrid.Dimensioned; q = q + 2)
                {
                    if (DatabaseFieldsGrid.StoredStuff[FieldNameIndex, q] == LocalFieldCode)
                    {
                        MessageBox.Show("Duplicate Field Code", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            
            
            LocalSave = true;
            Close();
 
        }
    }
}
