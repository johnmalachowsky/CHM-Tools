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
    public partial class Interfaces: Form
    {
        SQLiteDataAdapter da;
        DataSet ds;
        SQLiteCommandBuilder sqCommandBuilder;
        SQLiteConnection cn;
        bool LoadingGrid = false;
        string FileToUse, Password;

        public Interfaces(string DBLocation, string PW)
        {
            InitializeComponent();
            FileToUse = DBLocation;
            Password = PW;
        }

        private void FillGrid()
        {

            LoadingGrid = true;
            InterfacesGrid.DataSource = null;
            InterfacesGrid.Columns.Clear();

            SQLiteDataAdapter LBea1;
            DataSet LBdes1;
            SQLiteConnection LBen1;
            string LeBSQL1;
            SQLiteCommand LBecmd1;
            DataTable LBeet1;


            LBen1 = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
            LBen1.SetPassword(Password);

            LBen1.Open();

            LeBSQL1 = "Select * from InterfaceTypes order by Description";
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
            LBen2.SetPassword(Password);

            LBen2.Open();

            LeBSQL2 = "Select * from Rooms order by RoomName";
            LBecmd2 = new SQLiteCommand(LeBSQL2, LBen2);
            LBea2 = new SQLiteDataAdapter(LBecmd2);

            LBdes2 = new DataSet();
            LBea2.Fill(LBdes2);
            LBeet2 = LBdes2.Tables[0];

            SQLiteDataAdapter LBea3;
            DataSet LBdes3;
            SQLiteConnection LBen3;
            string LeBSQL3;
            SQLiteCommand LBecmd3;
            DataTable LBeet3;


            LBen3 = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
            LBen3.SetPassword(Password);

            LBen3.Open();

            LeBSQL3 = "Select * from PluginReference order by FileName";
            LBecmd3 = new SQLiteCommand(LeBSQL3, LBen3);
            LBea3 = new SQLiteDataAdapter(LBecmd3);

            LBdes3 = new DataSet();
            LBea3.Fill(LBdes3);
            LBeet3 = LBdes3.Tables[0];
            LBeet3.Rows.Add("");
            LBeet3.AcceptChanges();

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


            SQLiteDataAdapter LBea5;
            DataSet LBdes5;
            SQLiteConnection LBen5;
            string LeBSQL5;
            SQLiteCommand LBecmd5;
            DataTable LBeet5;


            LBen5 = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
            LBen5.SetPassword(Password);

            LBen5.Open();

            LeBSQL5 = "Select * from PluginReference order by FileName";
            LBecmd5 = new SQLiteCommand(LeBSQL5, LBen5);
            LBea5 = new SQLiteDataAdapter(LBecmd5);

            LBdes5 = new DataSet();
            LBea5.Fill(LBdes5);
            LBeet5 = LBdes5.Tables[0];
            LBeet5.Rows.Add("");
            LBeet5.AcceptChanges();



            cn = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
            cn.SetPassword(Password);

            cn.Open();
            string SQL;
            SQL = "SELECT * FROM Interfaces";
            SQLiteCommand cmd = new SQLiteCommand(SQL, cn);
            da = new SQLiteDataAdapter(cmd);
            ds = new DataSet();
    
            try
            {
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                bindingSource1.DataSource = dt;
                InterfacesNavigator.BindingSource = bindingSource1;
                InterfacesGrid.DataSource = bindingSource1;
                InterfacesGrid.AutoGenerateColumns = true;
                InterfacesGrid.Columns[0].Visible = false;
                InterfacesGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                InterfacesGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

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
            InterfacesGrid.Columns[2].Visible = false;
            col.DataSource = LBeet2;
            col.ValueMember = "UniqueID";
            col.DisplayMember = "RoomName";
            col.Name = col.HeaderText;
            col.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            col.Resizable = DataGridViewTriState.True;
            InterfacesGrid.Columns.Add(col);

            DataGridViewComboBoxColumn col1 = new DataGridViewComboBoxColumn();
            col1.DataPropertyName = "InterfaceType";
            col1.HeaderText = "InterfaceType";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            InterfacesGrid.Columns[3].Visible = false;
            col1.DataSource = LBeet1;
            col1.ValueMember = "Code";
            col1.DisplayMember = "Description";
            col1.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            col1.Resizable = DataGridViewTriState.True;
            col1.Name = col1.HeaderText;
            InterfacesGrid.Columns.Add(col1);

            DataGridViewComboBoxColumn col2 = new DataGridViewComboBoxColumn();
            col2.DataPropertyName = "PluginName";
            col2.HeaderText = "Plugin Name";
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            InterfacesGrid.Columns[7].Visible = false;
            col2.DataSource = LBeet3;
            col2.ValueMember = "FileName";
            col2.DisplayMember = "FileName";
            col2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            col2.Resizable = DataGridViewTriState.True;
            col2.Name = col2.HeaderText;

            InterfacesGrid.Columns.Add(col2);

            DataGridViewComboBoxColumn col3 = new DataGridViewComboBoxColumn();
            col3.DataPropertyName = "InterfaceUniqueID";
            col3.HeaderText = "Interface Connection";
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            InterfacesGrid.Columns[6].Visible = false;
            col3.DataSource = LBeet4;
            col3.ValueMember = "UniqueID";
            col3.DisplayMember = "InterfaceName";
            col3.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            col3.Resizable = DataGridViewTriState.True;
            col3.Name = col3.HeaderText;
            InterfacesGrid.Columns.Add(col3);

            DataGridViewComboBoxColumn col4 = new DataGridViewComboBoxColumn();
            col4.DataPropertyName = "ControllingDLL";
            col4.HeaderText = "DLL Contolling Data";
            col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            InterfacesGrid.Columns[9].Visible = false;
            col4.DataSource = LBeet5;
            col4.ValueMember = "FileName";
            col4.DisplayMember = "FileName";
            col4.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            col4.Resizable = DataGridViewTriState.True;
            col4.Name = col4.HeaderText;
            InterfacesGrid.Columns.Add(col4);

            InterfacesGrid.Columns[0].DisplayIndex = 14;
            InterfacesGrid.Columns[2].DisplayIndex = 14;
            InterfacesGrid.Columns[3].DisplayIndex = 14;
            InterfacesGrid.Columns[6].DisplayIndex = 14;
            InterfacesGrid.Columns[7].DisplayIndex = 14;

            InterfacesGrid.Columns[1].DisplayIndex = 0;
            InterfacesGrid.Columns[11].DisplayIndex = 1;
            InterfacesGrid.Columns[14].DisplayIndex = 2;
            InterfacesGrid.Columns[13].DisplayIndex = 3;
            InterfacesGrid.Columns[4].DisplayIndex = 4;
            InterfacesGrid.Columns[5].DisplayIndex = 5;
            InterfacesGrid.Columns[8].DisplayIndex = 6;
            InterfacesGrid.Columns[12].DisplayIndex = 7;
            InterfacesGrid.Columns[9].DisplayIndex = 8;
            InterfacesGrid.Columns[10].DisplayIndex = 9;
            for (int i = 0; i < InterfacesGrid.ColumnCount; i++)
                InterfacesGrid.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;



          
            InterfacesGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            if (InterfacesGrid.SortedColumn == null)
            {
                InterfacesGrid.Sort(InterfacesGrid.Columns[1], ListSortDirection.Ascending);
            }
            else
            {
                if (InterfacesGrid.SortOrder == SortOrder.Ascending)
                {
                    InterfacesGrid.Sort(InterfacesGrid.SortedColumn, ListSortDirection.Ascending);
                }
                else
                {
                    InterfacesGrid.Sort(InterfacesGrid.SortedColumn, ListSortDirection.Descending);
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
            InterfacesGrid.EndEdit();
            try
            {
                i = InterfacesGrid.CurrentCell.RowIndex;
            }
            catch (Exception ex)
            {
            }

            try
            {
                InterfacesGrid.EndEdit();
                if (InterfacesGrid.RowCount == 1)
                {
                    InterfacesGrid.CurrentCell = InterfacesGrid[1, 0];
                    bindingNavigatorAddNewItem1.PerformClick();
                    InterfacesGrid.CurrentCell = InterfacesGrid[1, 1];
                    bindingSource1.RemoveCurrent();
                    InterfacesGrid.CurrentCell = InterfacesGrid[1, 0];
                }
                else
                {
                    if (i > 1)
                        InterfacesGrid.CurrentCell = InterfacesGrid[1, i - 1];
                    else
                    {
                        InterfacesGrid.CurrentCell = InterfacesGrid[1, 0];
                        InterfacesGrid.CurrentCell = InterfacesGrid[1, 1];
                        InterfacesGrid.CurrentCell = InterfacesGrid[1, 0];

                    }
                    InterfacesGrid.CurrentCell = InterfacesGrid[1, i];
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                LoadingGrid = true;
                InterfacesGrid.EndEdit();
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
                if (InterfacesGrid.Rows[e.RowIndex].Cells[0].Value.ToString() == "")
                {
                    var o = (CHMGeneralTools)this.Owner;
                    InterfacesGrid.Rows[e.RowIndex].Cells[0].Value = o.GetUniqueID("I");
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
            MessageBox.Show("Error happened " + e.Context.ToString());

        }

        private void InterfacesGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 8)
                return;
        }

        delegate void SetColumnIndex(int i);

        private void Mymethod(int columnIndex)
        {
            InterfacesGrid.CurrentCell = InterfacesGrid.CurrentRow.Cells[columnIndex];
            InterfacesGrid.Focus();
        }

        private void InterfacesGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex !=8)
                return;
            
            System.Windows.Forms.DataGridView CC;
            CC=(System.Windows.Forms.DataGridView)sender;
            //Okay, Bring Up Startup Info
            SingleMultiLineInputForm InterfaceSingleMultiLineInputForm = new SingleMultiLineInputForm("Startup Information", "Serial Number",CC.CurrentCell.FormattedValue.ToString());
            InterfaceSingleMultiLineInputForm.ShowDialog();
//            InterfacesGrid.CancelEdit();
            if (InterfaceSingleMultiLineInputForm.Saved)
            {
                CC.CurrentCell.Value = InterfaceSingleMultiLineInputForm.Result;
                SaveAndContinue.Enabled = true;
                SaveAndExit.Enabled = true;
                toolStripButton9.Text = "Cancel Changes";
            }

            SetColumnIndex method = new SetColumnIndex(Mymethod);
             InterfacesGrid.BeginInvoke(method, 9);

            }
        }

    }
   

