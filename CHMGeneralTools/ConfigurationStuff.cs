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
    public partial class ConfigurationStuff : Form
    {
        SQLiteDataAdapter da;
        DataSet ds;
        SQLiteCommandBuilder sqCommandBuilder;
        SQLiteConnection cn;
        bool LoadingGrid = false;
        string FileToUse, Password;


        public ConfigurationStuff(string DB, string PW)
        {
            FileToUse = DB;
            InitializeComponent();
            Password = PW;
        }

        private void ConfigurationStuff_Shown(object sender, EventArgs e)
        {

            SQLiteDataAdapter LBda;
            DataSet LBds;
            SQLiteConnection LBcn;
            LBcn = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");

            LBcn.Open();
            string LBSQL;
            LBSQL = "Select Distinct ModuleSerialNumber from Configuration";
            SQLiteCommand LBcmd = new SQLiteCommand(LBSQL, LBcn);
            LBda = new SQLiteDataAdapter(LBcmd);
            LBds = new DataSet();
            try
            {
                LBda.Fill(LBds);
                DataTable LBdt = LBds.Tables[0];
                foreach (DataRow dr in LBdt.Rows)
                {
                    ModuleSerialNumber.Items.Add(dr[0].ToString());
                }
                ModuleSerialNumber.SelectedIndex = 0;
                LBcn.Close();
            }
            catch (Exception ex)
            {
            }

        }


        private void FillGrid()
        {
            if(ds!=null)
            {
                if (ds.HasChanges())
                {
                    if (MessageBox.Show("Do you Wish to Save the Changes", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConfigurationGrid.EndEdit();
                        da.Update(ds.Tables[0]);
                        ds.Tables[0].AcceptChanges();
                    }
                }
            }

            LoadingGrid = true;
            cn = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
            cn.Open();
            string SQL;
            SQL = "SELECT * FROM Configuration where ModuleSerialNumber = '" + ModuleSerialNumber.Items[ModuleSerialNumber.SelectedIndex].ToString()+"'";
            SQLiteCommand cmd = new SQLiteCommand(SQL, cn);
            da = new SQLiteDataAdapter(cmd);
            ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                bindingSource1.DataSource = dt;
                ConfigurationGridNavigator.BindingSource = bindingSource1;
                ConfigurationGrid.DataSource = bindingSource1;
                ConfigurationGrid.AutoGenerateColumns = true;
                ConfigurationGrid.Columns[0].Visible = false;

                ConfigurationGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ConfigurationGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                ConfigurationGrid.Columns[2].Width = (ConfigurationGrid.Size.Width - (20 + ConfigurationGrid.RowHeadersWidth)) - (ConfigurationGrid.Columns[1].Width + ConfigurationGrid.Columns[3].Width);

                if (ConfigurationGrid.ColumnCount < 5)
                {
                    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                    col.DataPropertyName = "ValueType";
                    col.HeaderText = "ValueType";
                    col.Width = ConfigurationGrid.Columns[3].Width;
                    ConfigurationGrid.Columns[3].Visible = false;

                    //col.DataSource = bindingSource1;
                    col.ValueMember = "ValueType";
                    col.DisplayMember = "ValueType";
                    col.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    col.Items.Add("P");
                    col.Items.Add("S");
                    ConfigurationGrid.Columns.Add(col);
                }
            }
            catch (Exception ex)
            {
                Close();
            }
            sqCommandBuilder = new SQLiteCommandBuilder(da);
            if (ConfigurationGrid.SortedColumn == null)
            {
                ConfigurationGrid.Sort(ConfigurationGrid.Columns[1], ListSortDirection.Ascending);
            }
            else
            {
                if (ConfigurationGrid.SortOrder == SortOrder.Ascending)
                {
                    ConfigurationGrid.Sort(ConfigurationGrid.SortedColumn, ListSortDirection.Ascending);
                }
                else
                {
                    ConfigurationGrid.Sort(ConfigurationGrid.SortedColumn, ListSortDirection.Descending);
                }
            }

            for(int i=0;i<ConfigurationGrid.ColumnCount;i++)
                ConfigurationGrid.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;

            
            
            LoadingGrid = false;
            SaveAndContinue.Enabled = false;
            SaveAndExit.Enabled = false;
            Cancel.Text = "Exit";


        }

        private void Save_Click(object sender, EventArgs e)
        {
            int i = 1;
            ConfigurationGrid.EndEdit();
            try
            {
                i = ConfigurationGrid.CurrentCell.RowIndex;
            }
            catch
            {
            }

            try
            {
                ConfigurationGrid.EndEdit();
                if (ConfigurationGrid.RowCount == 1)
                {
                    ConfigurationGrid.CurrentCell = ConfigurationGrid[1, 0];
                    bindingNavigatorAddNewItem.PerformClick();
                    ConfigurationGrid.CurrentCell = ConfigurationGrid[1, 1];
                    bindingSource1.RemoveCurrent();
                    ConfigurationGrid.CurrentCell = ConfigurationGrid[1, 0];
                }
                else
                {
                    if (i > 1)
                        ConfigurationGrid.CurrentCell = ConfigurationGrid[1, i - 1];
                    else
                    {
                        ConfigurationGrid.CurrentCell = ConfigurationGrid[1, 0];
                        ConfigurationGrid.CurrentCell = ConfigurationGrid[1, 1];
                        ConfigurationGrid.CurrentCell = ConfigurationGrid[1, 0];

                    }
                    ConfigurationGrid.CurrentCell = ConfigurationGrid[1, i];
                }
            }
            catch
            {
            }
            LoadingGrid = true;
            ConfigurationGrid.EndEdit();
            da.Update(ds.Tables[0]);
            ds.Tables[0].AcceptChanges();
            LoadingGrid = false;
            System.Windows.Forms.ToolStripButton B = (System.Windows.Forms.ToolStripButton)sender;
            SaveAndContinue.Enabled = false;
            SaveAndExit.Enabled = false;
            Cancel.Text = "Exit";
            if ((B.Name == "SaveAndExit"))
                Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfigurationStuff_FormClosing(object sender, FormClosingEventArgs e)
        {
           if(SaveAndContinue.Enabled)
            {
                if (MessageBox.Show("Are You Sure You want to leave without saving the changes", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }           
            }
        }

        private void ConfigurationStuff_FormClosed(object sender, FormClosedEventArgs e)
        {
            cn.Close();
        }

        private void ModuleSerialNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void NewModualSerialNumber_Click(object sender, EventArgs e)
        {
            SingleInputForm DatabaseSingleInputFormStuff = new SingleInputForm("New Module Serial Number", "Serial Number", "", "00000-00000");
            DatabaseSingleInputFormStuff.ShowDialog();
            if (DatabaseSingleInputFormStuff.Saved)
            {
                SQLiteConnection LBcn = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
                LBcn.Open();
                const string DATABASEQUOTE = "\"";
                string S = "insert into Configuration values (" + DATABASEQUOTE + DatabaseSingleInputFormStuff.Result + DATABASEQUOTE + "," + DATABASEQUOTE + "Placeholder" + DATABASEQUOTE + "," + DATABASEQUOTE + DatabaseSingleInputFormStuff.Result + DATABASEQUOTE + "," + DATABASEQUOTE + "P" + DATABASEQUOTE + ")";
                try
                {
                    SQLiteCommand mycommand = new SQLiteCommand(S, LBcn);
                    mycommand.ExecuteNonQuery();
                    int x=ModuleSerialNumber.Items.Add(DatabaseSingleInputFormStuff.Result);
                    if(x==ModuleSerialNumber.SelectedIndex)
                        FillGrid();
                    else
                        ModuleSerialNumber.SelectedIndex= x;
                    LBcn.Close();


                }
                catch
                {
                }

            }
        }

        private void ConfigurationGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!LoadingGrid)
            {
                if (ConfigurationGrid.Rows[e.RowIndex].Cells[0].Value.ToString()=="")
                {
                    ConfigurationGrid.Rows[e.RowIndex ].Cells[0].Value = ModuleSerialNumber.Items[ModuleSerialNumber.SelectedIndex].ToString();
                    ConfigurationGrid.Rows[e.RowIndex ].Cells[3].Value = "S";
                }
            }
        }

        private void ConfigurationGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            SaveAndContinue.Enabled = true;
            SaveAndExit.Enabled = true;
            Cancel.Text ="Cancel Changes";


        }

        private void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
        {
            SaveAndContinue.Enabled = true;
            SaveAndExit.Enabled = true;
            Cancel.Text = "Cancel Changes";
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You want to Delete This Record", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bindingSource1.RemoveCurrent();
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var o = (CHMGeneralTools)this.Owner;
            o.ExportGridToCSV((DataTable)bindingSource1.DataSource, "d:\\Configuration.csv");
            DataTable dt = (DataTable)bindingSource1.DataSource;
            dt.WriteXml("d:\\Configuration.xml");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            cn = new SQLiteConnection("Data Source=" + FileToUse + "; FailIfMissing=true");
            cn.Open();
            string SQL;
            SQL = "SELECT * FROM Configuration order by ModuleSerialNumber, fieldname";
            SQLiteCommand cmd = new SQLiteCommand(SQL, cn);
            da = new SQLiteDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            var o = (CHMGeneralTools)this.Owner;
            o.ExportGridToCSV((DataTable)dt, "d:\\ConfigurationRaw.csv");
            ds.Tables[0].WriteXml("d:\\ConfigurationRaw.xml");


        }
    }
}
