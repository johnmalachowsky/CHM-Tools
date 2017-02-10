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
    public partial class Rooms: Form
    {
        SQLiteDataAdapter da;
        DataSet ds;
        SQLiteCommandBuilder sqCommandBuilder;
        SQLiteConnection cn;
        bool LoadingGrid = false;
        string FileToUse, Password;


        public Rooms(string DBLocation, string PW)
        {
            InitializeComponent();
            FileToUse = DBLocation;
            Password = PW;

        }

        private void FillGrid()
        {
            LoadingGrid = true;
            cn = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
            cn.SetPassword(Password);
            cn.Open();
            string SQL;
            SQL = "SELECT * FROM Rooms";
            SQLiteCommand cmd = new SQLiteCommand(SQL, cn);
            da = new SQLiteDataAdapter(cmd);
            ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                bindingSource1.DataSource = dt;
                RoomsNavigator.BindingSource = bindingSource1;
                RoomsGrid.DataSource = bindingSource1;
                RoomsGrid.AutoGenerateColumns = true;
                RoomsGrid.Columns[0].Visible = false;
                RoomsGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                RoomsGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

         }
            catch (Exception ex)
            {
                Close();
            }
            sqCommandBuilder = new SQLiteCommandBuilder(da);
            if (RoomsGrid.SortedColumn == null)
            {
 //               RoomsGrid.Sort(RoomsGrid.Columns[1], ListSortDirection.Ascending);
            }
            else
            {
                if (RoomsGrid.SortOrder == SortOrder.Ascending)
                {
                    RoomsGrid.Sort(RoomsGrid.SortedColumn, ListSortDirection.Ascending);
                }
                else
                {
                    RoomsGrid.Sort(RoomsGrid.SortedColumn, ListSortDirection.Descending);
                }
            }

            for (int i = 0; i < RoomsGrid.ColumnCount; i++)
                RoomsGrid.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
           
            LoadingGrid = false;
            SaveAndContinue.Enabled = false;
            SaveAndExit.Enabled = false;
            toolStripButton9.Text = "Exit";


        }

        private void Save_Click(object sender, EventArgs e)
        {
            int i = 1;
            RoomsGrid.EndEdit();
            try
            {
                i = RoomsGrid.CurrentCell.RowIndex;
            }
            catch (Exception ex)
            {
            }

            try
            {
                RoomsGrid.EndEdit();
                if (RoomsGrid.RowCount == 1)
                {
                    RoomsGrid.CurrentCell = RoomsGrid[1, 0];
                    bindingNavigatorAddNewItem1.PerformClick();
                    RoomsGrid.CurrentCell = RoomsGrid[1, 1];
                    bindingSource1.RemoveCurrent();
                    RoomsGrid.CurrentCell = RoomsGrid[1, 0];
                }
                else
                {
                    if (i > 1)
                        RoomsGrid.CurrentCell = RoomsGrid[1, i - 1];
                    else
                    {
                        RoomsGrid.CurrentCell = RoomsGrid[1, 0];
                        RoomsGrid.CurrentCell = RoomsGrid[1, 1];
                        RoomsGrid.CurrentCell = RoomsGrid[1, 0];

                    }
                    RoomsGrid.CurrentCell = RoomsGrid[1, i];
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                LoadingGrid = true;
                RoomsGrid.EndEdit();
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

 
         private void Rooms_Shown(object sender, EventArgs e)
        {
            FillGrid();
        }

         private void RoomsGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!LoadingGrid)
            {
                if (RoomsGrid.Rows[e.RowIndex].Cells[0].Value.ToString() == "")
                {
                    var o = (CHMGeneralTools)this.Owner;
                    RoomsGrid.Rows[e.RowIndex].Cells[0].Value = o.GetUniqueID("R");
                }
            }
 
        }

        private void Rooms_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(SaveAndContinue.Enabled)
            {
                if (MessageBox.Show("Are You Sure You want to leave without saving the changes", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
           }
        }

        private void Rooms_FormClosed(object sender, FormClosedEventArgs e)
        {
            cn.Close();

        }

        private void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            SaveAndContinue.Enabled = true;
            SaveAndExit.Enabled = true;
            toolStripButton9.Text="Cancel Changes";
        }

        private void RoomsGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
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

    }
}
