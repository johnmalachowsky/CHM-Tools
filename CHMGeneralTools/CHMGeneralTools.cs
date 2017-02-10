using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace ProgrammingTools
{
   
    public partial class CHMGeneralTools : Form
    {
        string DBToUse;
        string EncryptedMasterPassword;

        public CHMGeneralTools()
        {
            InitializeComponent();
            String[] arguments = Environment.GetCommandLineArgs();

            if (arguments.Count() == 2)
            {
                DBToUse = arguments[1];
                if (!File.Exists(DBToUse))
                    DBToUse = null;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pluginCommandDocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PluginCommandsGrid PluginCommandsGridForm = new PluginCommandsGrid();
            PluginCommandsGridForm.ShowDialog();
            PluginCommandsGridForm.Close();
        }

        private void databaseFieldDocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseFieldsGrid DatabaseFieldsGridForm = new DatabaseFieldsGrid();
            DatabaseFieldsGridForm.ShowDialog();
            DatabaseFieldsGridForm.Close();
        }

        private void configurationInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetDBName();
            ConfigurationStuff ConfigurationStuffForm = new ConfigurationStuff(DBToUse,EncryptedMasterPassword);
            ConfigurationStuffForm.Owner = this;
            ConfigurationStuffForm.ShowDialog();
            ConfigurationStuffForm.Close();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetDBName();
            Rooms RoomsForm = new Rooms(DBToUse, EncryptedMasterPassword);
            RoomsForm.Owner = this;
            RoomsForm.ShowDialog();
            RoomsForm.Close();
        }

        public void ExportGridToCSV(DataTable dt, string FileLocation)
        {
            // Create the CSV file to which grid data will be exported.
            StreamWriter sw = new StreamWriter(FileLocation, false);
            // First we will write the headers.
//            DataTable dt = ((DataSet)grid1.DataSource).Tables[0];

            int iColCount = dt.Columns.Count;
            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            // Now write all the rows.
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }
                    if (i < iColCount - 1)
                    {
                        sw.Write(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        public DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add();
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }


        public string GetUniqueID(string Code)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random((int)DateTime.Now.Ticks);
            char ch;
            for (int i = 0; i < 12; i++)
            {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(74 * random.NextDouble() + 48)));
                    builder.Append(ch);
            }

            return Code.ToUpper()+builder.ToString();
        }

        private void systemDataLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogViewer LogViewerForm = new LogViewer("Startup System Data Logs", "Startup System Data Logs | SysDataLogsS*.txt");
            LogViewerForm.ShowDialog();
            LogViewerForm.Close();
        }

        private void flagLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogViewer LogViewerForm = new LogViewer("Startup Flag Logs", "Startup Flag Logs | FlagLogsS*.txt");
            LogViewerForm.ShowDialog();
            LogViewerForm.Close();
        }

        private void messageLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogViewer LogViewerForm = new LogViewer("Startup Message Logs", "Startup Message Logs | MessageLogsS*.txt");
            LogViewerForm.ShowDialog();
            LogViewerForm.Close();
            LogViewerForm.Close();
        }

        private void errorLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogViewer LogViewerForm = new LogViewer("Startup Error Logs", "Startup Error Logs | ErrorLogsS*.txt");
            LogViewerForm.ShowDialog();
            LogViewerForm.Close();
        }

        private void systemDataLogsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogViewer LogViewerForm = new LogViewer("Ending System Data Logs", "Ending System Data Logs | SysDataLogsF*.txt");
            LogViewerForm.ShowDialog();
            LogViewerForm.Close();
        }

        private void flagLogsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogViewer LogViewerForm = new LogViewer("Ending Flag Logs", "Ending Flag Logs | FlagLogsF*.txt");
            LogViewerForm.ShowDialog();
            LogViewerForm.Close();
        }

        private void messageLogsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogViewer LogViewerForm = new LogViewer("Ending Message Logs", "Ending Message Logs | MessageLogsF*.txt");
            LogViewerForm.ShowDialog();
            LogViewerForm.Close();
        }

        private void errorLogsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogViewer LogViewerForm = new LogViewer("Ending Error Logs", "Ending Error Logs | ErrorLogsF*.txt");
            LogViewerForm.ShowDialog();
            LogViewerForm.Close();
        }

        private void GetDBName()
        {
            if (!string.IsNullOrEmpty(DBToUse))
                return;
            
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(@"DatabaseLocation");

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    foreach (XmlNode Cnode in node)
                    {
                        if (node.Name == "LastPath")
                        {
                            openFileDialog1.InitialDirectory = node.InnerText;
                        }

                    }
                }
            }
            catch
            {
            }



            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK)
            {
                Close();
                return;
            }
            DBToUse = openFileDialog1.FileName;
            XmlDocument Data = new XmlDocument();
            XmlNode DataNode = Data.CreateXmlDeclaration("1.0", "UTF-8", null);
            Data.AppendChild(DataNode);

            XmlNode DataNodeRoot;
            XmlNode DataNodeNode;

            DataNodeRoot = Data.CreateElement("DataBaseLocation");
            Data.AppendChild(DataNodeRoot);

            DataNodeNode = Data.CreateElement("LastPath");
            DataNodeNode.AppendChild(Data.CreateTextNode(Path.GetDirectoryName(DBToUse)));
            DataNodeRoot.AppendChild(DataNodeNode);
            Data.Save("DatabaseLocation");

            EnterPasswordForm EnterPassword = new EnterPasswordForm("Enter Database Password");
            EnterPassword.ShowDialog();
            EnterPassword.Close();
            if (EnterPassword.Saved)
                EncryptedMasterPassword = EnterPassword.EnteredPassword;
            else
                EncryptedMasterPassword = "";
                return;

       }

        private void devicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetDBName();
            Interfaces InterfacesForm = new Interfaces(DBToUse, EncryptedMasterPassword);
            InterfacesForm.Owner = this;
            InterfacesForm.ShowDialog();
            InterfacesForm.Close();

        }

         private void sensorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetDBName();
            Sensors SensorsForm = new Sensors(DBToUse);
            SensorsForm.Owner = this;
            SensorsForm.ShowDialog();
            SensorsForm.Close();
        }

        private void devicesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetDBName();
            Devices DevicesForm = new Devices(DBToUse,EncryptedMasterPassword);
            DevicesForm.Owner = this;
            DevicesForm.ShowDialog();
            DevicesForm.Close();

        }

        private void encryptStartupFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "StartupFile|CHMInit.001";
            openFileDialog1.FileName = "CHMInit.001";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK)
            {
                Close();
                return;
            }
            string FileToUse = openFileDialog1.FileName;
            FileStream fs = File.OpenRead(FileToUse);
            byte[] DeEncryptedFile = new byte[fs.Length];
            fs.Read(DeEncryptedFile, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            Byte[] EncryptedFile = ProtectedData.Protect(DeEncryptedFile, null, DataProtectionScope.LocalMachine);

            FileStream _FileStream = new FileStream(FileToUse, FileMode.Create, FileAccess.Write);
            _FileStream.Write(EncryptedFile, 0, EncryptedFile.Length);
            _FileStream.Close();
        }
    }
}
