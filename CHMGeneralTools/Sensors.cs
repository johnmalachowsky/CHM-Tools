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
    public partial class Sensors: Form
    {
        SQLiteDataAdapter da;
        DataSet ds;
        SQLiteCommandBuilder sqCommandBuilder;
        SQLiteConnection cn;
        bool LoadingGrid = false;
        string FileToUse;

        public Sensors(string DBLocation)
        {
            InitializeComponent();
            FileToUse = DBLocation;
        }

        private void FillGrid()
        {

            LoadingGrid = true;
            SensorsGrid.DataSource = null;
            SensorsGrid.Columns.Clear();

            SQLiteDataAdapter LBea1;
            DataSet LBdes1;
            SQLiteConnection LBen1;
            string LeBSQL1;
            SQLiteCommand LBecmd1;
            DataTable LBeet1;


            LBen1 = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
            LBen1.Open();

            LeBSQL1 = "Select * from SensorTypes order by Description";
            LBecmd1 = new SQLiteCommand(LeBSQL1, LBen1);
            LBea1 = new SQLiteDataAdapter(LBecmd1);

            LBdes1 = new DataSet();
            LBea1.Fill(LBdes1);
            LBeet1 = LBdes1.Tables[0];


            SQLiteDataAdapter LBea2;
            DataSet LBdes2;
            SQLiteConnection LBen2;
            string LeBSQL2;
            SQLiteCommand LBecmd2;
            DataTable LBeet2;


            LBen2 = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
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
            LBen4.Open();

            LeBSQL4 = "Select * from Interfaces order by InterfaceName";
            LBecmd4 = new SQLiteCommand(LeBSQL4, LBen4);
            LBea4 = new SQLiteDataAdapter(LBecmd4);

            LBdes4 = new DataSet();
            LBea4.Fill(LBdes4);
            LBeet4 = LBdes4.Tables[0];

            
            
            cn = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
            cn.Open();
            string SQL;
            SQL = "SELECT * FROM Sensors";
            SQLiteCommand cmd = new SQLiteCommand(SQL, cn);
            da = new SQLiteDataAdapter(cmd);
            ds = new DataSet();
    
            try
            {
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                bindingSource1.DataSource = dt;
                SensorsNavigator.BindingSource = bindingSource1;
                SensorsGrid.DataSource = bindingSource1;
                SensorsGrid.AutoGenerateColumns = true;
                SensorsGrid.Columns[0].Visible = false;
                SensorsGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                SensorsGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

         }
            catch (Exception ex)
            {
                Close();
            }
            sqCommandBuilder = new SQLiteCommandBuilder(da);
            
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.DataPropertyName = "RoomUniqueID";
            col.HeaderText = "Room";
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            SensorsGrid.Columns[3].Visible = false;
            col.DataSource = LBeet2;
            col.ValueMember = "UniqueID";
            col.DisplayMember = "RoomName";
            col.Name = col.HeaderText;
            col.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            col.Resizable = DataGridViewTriState.True;
            SensorsGrid.Columns.Add(col);

            DataGridViewComboBoxColumn col1 = new DataGridViewComboBoxColumn();
            col1.DataPropertyName = "SensorType";
            col1.HeaderText = "SensorType";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            SensorsGrid.Columns[2].Visible = false;
            col1.DataSource = LBeet1;
            col1.ValueMember = "Code";
            col1.DisplayMember = "Description";
            col1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            col1.Resizable = DataGridViewTriState.True;
            col1.Name = col1.HeaderText;
            SensorsGrid.Columns.Add(col1);

            DataGridViewComboBoxColumn col3 = new DataGridViewComboBoxColumn();
            col3.DataPropertyName = "InterfaceUniqueID";
            col3.HeaderText = "Interface Connection";
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            SensorsGrid.Columns[4].Visible = false;
            col3.DataSource = LBeet4;
            col3.ValueMember = "UniqueID";
            col3.DisplayMember = "InterfaceName";
            col3.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            col3.Resizable = DataGridViewTriState.True;
            col3.Name = col3.HeaderText;
            SensorsGrid.Columns.Add(col3);

            SensorsGrid.Columns[0].DisplayIndex = 0;
            SensorsGrid.Columns[1].DisplayIndex = 0;
            SensorsGrid.Columns[2].DisplayIndex = 0;
            SensorsGrid.Columns[3].DisplayIndex = 0;
            SensorsGrid.Columns[4].DisplayIndex = 0;
            SensorsGrid.Columns[5].DisplayIndex = 0;
            SensorsGrid.Columns[6].DisplayIndex = 0;
            SensorsGrid.Columns[7].DisplayIndex = 0;
            SensorsGrid.Columns[8].DisplayIndex = 0;
            SensorsGrid.Columns[9].DisplayIndex = 0;

            SensorsGrid.Columns[1].DisplayIndex = 0;
            SensorsGrid.Columns[8].DisplayIndex = 1;
            SensorsGrid.Columns[5].DisplayIndex = 2;
            SensorsGrid.Columns[7].DisplayIndex = 3;
            SensorsGrid.Columns[9].DisplayIndex = 4;
            SensorsGrid.Columns[6].DisplayIndex = 5;

            for (int i = 0; i < SensorsGrid.ColumnCount; i++)
                SensorsGrid.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
 

          
            SensorsGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            if (SensorsGrid.SortedColumn == null)
            {
                SensorsGrid.Sort(SensorsGrid.Columns[1], ListSortDirection.Ascending);
            }
            else
            {
                if (SensorsGrid.SortOrder == SortOrder.Ascending)
                {
                    SensorsGrid.Sort(SensorsGrid.SortedColumn, ListSortDirection.Ascending);
                }
                else
                {
                    SensorsGrid.Sort(SensorsGrid.SortedColumn, ListSortDirection.Descending);
                }
            }
           
            LoadingGrid = false;
            SaveAndContinue.Enabled = false;
            SaveAndExit.Enabled = false;
            toolStripButton9.Text = "Exit";


        }

        private void Save_Click(object sender, EventArgs e)
        {
            int i = 1;
            SensorsGrid.EndEdit();
            try
            {
                i = SensorsGrid.CurrentCell.RowIndex;
            }
            catch (Exception ex)
            {
            }

            try
            {
                SensorsGrid.EndEdit();
                if (SensorsGrid.RowCount == 1)
                {
                    SensorsGrid.CurrentCell = SensorsGrid[1, 0];
                    bindingNavigatorAddNewItem1.PerformClick();
                    SensorsGrid.CurrentCell = SensorsGrid[1, 1];
                    bindingSource1.RemoveCurrent();
                    SensorsGrid.CurrentCell = SensorsGrid[1, 0];
                }
                else
                {
                    if (i > 1)
                        SensorsGrid.CurrentCell = SensorsGrid[1, i - 1];
                    else
                    {
                        SensorsGrid.CurrentCell = SensorsGrid[1, 0];
                        SensorsGrid.CurrentCell = SensorsGrid[1, 1];
                        SensorsGrid.CurrentCell = SensorsGrid[1, 0];

                    }
                    SensorsGrid.CurrentCell = SensorsGrid[1, i];
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                LoadingGrid = true;
                SensorsGrid.EndEdit();
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
                if (SensorsGrid.Rows[e.RowIndex].Cells[0].Value.ToString() == "")
                {
                    var o = (CHMGeneralTools)this.Owner;
                    SensorsGrid.Rows[e.RowIndex].Cells[0].Value = o.GetUniqueID("S");
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
            MessageBox.Show("Error happened " + e.Context.ToString());

        }

    }

   
}
