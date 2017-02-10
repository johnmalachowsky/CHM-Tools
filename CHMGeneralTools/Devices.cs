using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace ProgrammingTools
{
    public partial class Devices: Form
    {
        SQLiteDataAdapter da;
        DataSet ds;
        SQLiteCommandBuilder sqCommandBuilder;
        SQLiteConnection cn;
        bool LoadingGrid = false;
        string FileToUse, Password;

        

        public Devices(string DBLocation, string PW)
        {
            InitializeComponent();
            FileToUse = DBLocation;
            Password = PW;
        }

        private void FillGrid()
        {

            LoadingGrid = true;
            DevicesGrid.DataSource = null;
            DevicesGrid.Columns.Clear();

            //SQLiteDataAdapter LBea1;
            //DataSet LBdes1;
            //SQLiteConnection LBen1;
            //string LeBSQL1;
            //SQLiteCommand LBecmd1;
            //DataTable LBeet1;


            //LBen1 = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
            //LBen1.SetPassword(Password);
            //LBen1.Open();

            //LeBSQL1 = "Select * from DeviceTypes order by Description";
            //LBecmd1 = new SQLiteCommand(LeBSQL1, LBen1);
            //LBea1 = new SQLiteDataAdapter(LBecmd1);

            //LBdes1 = new DataSet();
            //LBea1.Fill(LBdes1);
            //LBeet1 = LBdes1.Tables[0];


            SQLiteDataAdapter LBea2;
            DataSet LBdes2;
            SQLiteConnection LBen2;
            string LeBSQL2;
            SQLiteCommand LBecmd2;
            DataTable LBeet2;


            LBen2 = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
            LBen2.SetPassword(Password); 
            LBen2.Open();

            LeBSQL2 = "Select * from Rooms order by RoomName";
            LBecmd2 = new SQLiteCommand(LeBSQL2, LBen2);
            LBea2 = new SQLiteDataAdapter(LBecmd2);

            LBdes2 = new DataSet();
            LBea2.Fill(LBdes2);
            LBeet2 = LBdes2.Tables[0];


            SQLiteDataAdapter LBea4;
            DataSet LBdes4;
            SQLiteConnection LBen4;
            string LeBSQL4;
            SQLiteCommand LBecmd4;
            DataTable LBeet4;


            LBen4 = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
            LBen4.SetPassword(Password);
            LBen4.Open();

            LeBSQL4 = "Select * from Interfaces order by InterfaceName";
            LBecmd4 = new SQLiteCommand(LeBSQL4, LBen4);
            LBea4 = new SQLiteDataAdapter(LBecmd4);

            LBdes4 = new DataSet();
            LBea4.Fill(LBdes4);
            LBeet4 = LBdes4.Tables[0];

            
            
            cn = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
            cn.SetPassword(Password);
            cn.Open();

            string SQL;
            SQL = "SELECT * FROM Devices";
            SQLiteCommand cmd = new SQLiteCommand(SQL, cn);
            da = new SQLiteDataAdapter(cmd);
            ds = new DataSet();
    
            try
            {
                da.Fill(ds);
                var x=ds.Tables[0].PrimaryKey;
                DataTable dt = ds.Tables[0];
                bindingSource1.DataSource = dt;

            }
            catch (Exception ex)
            {
                Close();
            }
            sqCommandBuilder = new SQLiteCommandBuilder(da);
            try
            {
                DevicesNavigator.BindingSource = bindingSource1;
                DevicesGrid.AutoGenerateColumns = true;
                DevicesGrid.DataSource = bindingSource1;
                DevicesGrid.Columns[0].Visible = false;
                DevicesGrid.Columns[23].Visible = false;
                DevicesGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DevicesGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch
            {

            }

            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.DataPropertyName = "RoomUniqueID";
            col.HeaderText = "Room";
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //DevicesGrid.Columns[2].Visible = false;
            col.DataSource = LBeet2;
            col.ValueMember = "UniqueID";
            col.DisplayMember = "RoomName";
            col.Name = col.HeaderText;
            col.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            col.Resizable = DataGridViewTriState.True;
            col.AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells;
            DevicesGrid.Columns.Add(col);

            DataGridViewComboBoxColumn col3 = new DataGridViewComboBoxColumn();
            col3.DataPropertyName = "InterfaceUniqueID";
            col3.HeaderText = "Interface Connection";
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //DevicesGrid.Columns[4].Visible = false;
            col3.DataSource = LBeet4;
            col3.ValueMember = "UniqueID";
            col3.DisplayMember = "InterfaceName";
            col3.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            col3.Resizable = DataGridViewTriState.True;
            col3.Name = col3.HeaderText;
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DevicesGrid.Columns.Add(col3);

            DevicesGrid.Columns[4].Visible = false;
            DevicesGrid.Columns[5].Visible = false;
            DevicesGrid.Columns[25].DisplayIndex = 4;
            DevicesGrid.Columns[26].DisplayIndex = 5;

            LoadingGrid = false;
            SaveAndContinue.Enabled = false;
            SaveAndExit.Enabled = false;
            toolStripButton9.Text = "Exit";
           // DevicesGrid.Sort(DevicesGrid.Columns[0], ListSortDirection.Ascending);


        }

        private void Save_Click(object sender, EventArgs e)
        {
            int i = 1;
            DevicesGrid.EndEdit();
            try
            {
                i = DevicesGrid.CurrentCell.RowIndex;
            }
            catch (Exception ex)
            {
            }

            try
            {
                DevicesGrid.EndEdit();
                if (DevicesGrid.RowCount == 1)
                {
                    DevicesGrid.CurrentCell = DevicesGrid[1, 0];
                    bindingNavigatorAddNewItem1.PerformClick();
                    DevicesGrid.CurrentCell = DevicesGrid[1, 1];
                    bindingSource1.RemoveCurrent();
                    DevicesGrid.CurrentCell = DevicesGrid[1, 0];
                }
                else
                {
                    if (i > 1)
                        DevicesGrid.CurrentCell = DevicesGrid[1, i - 1];
                    else
                    {
                        DevicesGrid.CurrentCell = DevicesGrid[1, 0];
                        DevicesGrid.CurrentCell = DevicesGrid[1, 1];
                        DevicesGrid.CurrentCell = DevicesGrid[1, 0];

                    }
                    DevicesGrid.CurrentCell = DevicesGrid[1, i];
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                LoadingGrid = true;
                DevicesGrid.EndEdit();
                da.Update(ds.Tables[0]);
                ds.Tables[0].AcceptChanges();
                FillGrid();
                LoadingGrid = false;
            }
            catch (Exception ex)
            {
            }

            System.Windows.Forms.ToolStripButton B = (System.Windows.Forms.ToolStripButton)sender;
            if ((B.Name == "SaveAndExit"))
                Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

 
         private void Devices_Shown(object sender, EventArgs e)
        {
 
            FillGrid();
        }

         private void DevicesGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!LoadingGrid)
            {
                if (DevicesGrid.Rows[e.RowIndex].Cells[0].Value.ToString() == "")
                {
                    var o = (CHMGeneralTools)this.Owner;
                    DevicesGrid.Rows[e.RowIndex].Cells[0].Value = o.GetUniqueID("D");
                }
            }
 
        }

        private void Devices_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(SaveAndContinue.Enabled)
            {
                if (MessageBox.Show("Are You Sure You want to leave without saving the changes", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
           }
        }

        private void Devices_FormClosed(object sender, FormClosedEventArgs e)
        {
            cn.Close();

        }

        private void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            SaveAndContinue.Enabled = true;
            SaveAndExit.Enabled = true;
            toolStripButton9.Text="Cancel Changes";
        }

        private void DevicesGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            SaveAndContinue.Enabled = true;
            SaveAndExit.Enabled = true;
            toolStripButton9.Text = "Cancel Changes";
        }

        private void bindingNavigatorDeleteItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You want to Delete This Record", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bindingSource1.RemoveCurrent();
            }
            
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void DevicesGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "Parameter is not valid." || e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
                return;
            MessageBox.Show("Error happened " + e.Exception.ToString()+"\r\n"+e.ColumnIndex.ToString()+"/"+e.RowIndex.ToString() );

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int i=bindingSource1.Position;
            string[] S=new string[22];
            for(int p=0;p<22;p++)
                S[p]= DevicesGrid[p, i].Value.ToString();
            bindingSource1.AddNew();
            int np = bindingSource1.Position;
            for (int p = 1; p < 22; p++)
                DevicesGrid[p, np].Value=S[p];
            //DevicesGrid[0, np].Value = "DXXXTESTR";


        }

        private void DevicesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }

   
}
