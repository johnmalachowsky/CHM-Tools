using System;
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
    public partial class DatabaseFieldsGrid : Form
    {
        string FileToUse;
        bool Changed = false;
        int ColumnSorted = 0;
        static public string[, ] StoredStuff;
        int LastStoredStuff = 0;
        static public int Dimensioned = 99;

        public DatabaseFieldsGrid()
        {
            InitializeComponent();
        }

        private void DatabaseFieldsGrid_Shown(object sender, EventArgs e)
        {
            int i;
            StoredStuff = new string[Dimensioned, Dimensioned];
            
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            DatabaseGrid.Columns.Add("Field Code", -2, HorizontalAlignment.Left);
            DatabaseGrid.Columns.Add("Field Code Description", -2, HorizontalAlignment.Left);
            DatabaseGrid.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

      
            
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(@"DatabaseFields");

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
            FileToUse = openFileDialog1.FileName;
            DatabaseName.Text = Path.GetFileNameWithoutExtension(@FileToUse);
            XmlDocument Data = new XmlDocument();
            XmlNode DataNode = Data.CreateXmlDeclaration("1.0", "UTF-8", null);
            Data.AppendChild(DataNode);

            XmlNode DataNodeRoot;
            XmlNode DataNodeNode;

            DataNodeRoot = Data.CreateElement("DataBaseFieldsDocumentation");
            Data.AppendChild(DataNodeRoot);

            DataNodeNode = Data.CreateElement("LastPath");
            DataNodeNode.AppendChild(Data.CreateTextNode(Path.GetDirectoryName(FileToUse)));
            DataNodeRoot.AppendChild(DataNodeNode);
            Data.Save("DataBaseFields");

            try
            {
                doc.Load(@FileToUse);
                DatabaseName.Text = Path.GetFileNameWithoutExtension(@FileToUse);
                LastStoredStuff = 0;

                 foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = node.Name;
                    item.Value = LastStoredStuff;
                    LastStoredStuff++;
                    Fields.Items.Add(item);
                    i = 0;
                    foreach (XmlNode Cnode in node)
                    {
                        StoredStuff[LastStoredStuff - 1, i] = Cnode.Attributes.GetNamedItem("Code").Value;
                        StoredStuff[LastStoredStuff - 1, i + 1] = Cnode.FirstChild.InnerText;
                        i = i + 2;
                    }
                }
                if(Fields.Items.Count>0)
                    Fields.SelectedIndex = 0;
            }
            catch
            {
            }
            Save.Enabled = false;

        }

        private void Save_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            int index, index2;
            ComboboxItem item = new ComboboxItem();

            try
            {

                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);

                XmlNode CommandsRoot;
                XmlNode CommandNode;
                XmlNode CommandInfoNode;
                XmlAttribute CommandAttribute;

                CommandsRoot = doc.CreateElement(DatabaseName.Text);
                doc.AppendChild(CommandsRoot);

                for(index=0;index<Fields.Items.Count;index++)
                {

                    item = (ComboboxItem)Fields.Items[index];
                    CommandNode = doc.CreateElement(item.Text);
                    CommandsRoot.AppendChild(CommandNode);

                    for (index2 = 0; index2 < Dimensioned; index2 = index2 + 2)
                    {
                        if (!string.IsNullOrEmpty(StoredStuff[(int)item.Value, index2]))
                        {
                            
                            CommandInfoNode = doc.CreateElement("Identifer");
                            CommandAttribute=doc.CreateAttribute("Code");
                            CommandAttribute.Value = StoredStuff[(int)item.Value, index2];
                            CommandInfoNode.Attributes.Append(CommandAttribute);

                            CommandInfoNode.AppendChild(doc.CreateTextNode(StoredStuff[(int)item.Value, index2+1]));
                            CommandNode.AppendChild(CommandInfoNode);
                        }
                    
                    }
                }

                doc.Save(Path.ChangeExtension(FileToUse, "tmp"));
                try
                {
                    File.Delete(Path.ChangeExtension(FileToUse, "bak"));
                    if(File.Exists(FileToUse))
                    {
                        File.Move(FileToUse, Path.ChangeExtension(FileToUse, "bak"));
                    }
                    File.Move(Path.ChangeExtension(FileToUse, "tmp"), FileToUse);

                }
                catch
                {
                }
                MessageBox.Show(DatabaseName.Text, "Database Field Documentation File Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Save.Enabled = false;
                Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error Updating Plugin Documentation", MessageBoxButtons.OK, MessageBoxIcon.Error);
 
            }
        }

        private void AddField_Click(object sender, EventArgs e)
        {
            int i;
            ComboboxItem item2 = new ComboboxItem();

            SingleInputForm DatabaseSingleInputFormStuff = new SingleInputForm("New Database Field", "New Field","","");
            DatabaseSingleInputFormStuff.ShowDialog();
            if (DatabaseSingleInputFormStuff.Saved)
            {
                for(i=0;i<Fields.Items.Count;i++)
                {
                    item2 = (ComboboxItem)Fields.Items[i];
                    if (DatabaseSingleInputFormStuff.Result.Trim().ToUpper().Replace(" ", "") == item2.Text.Trim().ToUpper())
                    {
                        MessageBox.Show("Duplicate Field", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;

                    }
                }



                ComboboxItem item = new ComboboxItem();
                item.Text = DatabaseSingleInputFormStuff.Result.Trim().Replace(" ", "");
                item.Value = LastStoredStuff;

                i=Fields.Items.Add(item);
                LastStoredStuff++;
                Fields.SelectedIndex = i;
                Save.Enabled = true;

            }
        }

        private void AddFieldCodes_Click(object sender, EventArgs e)
        {
            int i, q;
            
            ListViewItem item;
            ComboboxItem CItem=(ComboboxItem)Fields.Items[Fields.SelectedIndex];
            i = (int)CItem.Value;
            FieldCodes DatabaseFieldCodesStuff = new FieldCodes(DatabaseName.Text, "", "",i);
            DatabaseFieldCodesStuff.ShowDialog();
            if (DatabaseFieldCodesStuff.LocalSave)
            {
                item = DatabaseGrid.Items.Add(DatabaseFieldCodesStuff.LocalFieldCode);
                item.SubItems.Add(DatabaseFieldCodesStuff.LocalFieldCodeDescription);
 
                for (q = 0; q < Dimensioned; q = q + 2)
                {
                    if (string.IsNullOrEmpty(StoredStuff[i, q]))
                    {
                        StoredStuff[i, q]=DatabaseFieldCodesStuff.LocalFieldCode;
                        StoredStuff[i, q + 1] = DatabaseFieldCodesStuff.LocalFieldCodeDescription;
                        item.Tag = q;
                        break;
                    }
                }
                Save.Enabled = true;

           }

        }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void Fields_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataBaseGrid();
        }

        private void FillDataBaseGrid()
        {
            
            int i,index;
            ComboboxItem comboitem = new ComboboxItem();

            comboitem = (ComboboxItem)Fields.Items[Fields.SelectedIndex];
            index = (int)comboitem.Value;
            DatabaseGrid.Items.Clear();
            for(i=0;i<Dimensioned;i=i+2)
            {
                if (!string.IsNullOrEmpty(StoredStuff[index, i]))
                {
                    ListViewItem item = DatabaseGrid.Items.Add(StoredStuff[index, i]);
                    item.SubItems.Add(StoredStuff[index, i+1]);
                    item.Tag = i;            
                }

            }


        }

        private void DatabaseGrid_DoubleClick(object sender, EventArgs e)
        {
            int index, index1;
            ComboboxItem comboitem = new ComboboxItem();

            comboitem = (ComboboxItem)Fields.Items[Fields.SelectedIndex];
            index = (int)comboitem.Value;
            
            ListViewItem item = DatabaseGrid.SelectedItems[0];
            index1=(int) item.Tag;
            FieldCodes DatabaseFieldCodesStuff = new FieldCodes(DatabaseName.Text, StoredStuff[index, index1], StoredStuff[index, index1 + 1],index);
            DatabaseFieldCodesStuff.ShowDialog();
            if (DatabaseFieldCodesStuff.LocalSave)
            {
                StoredStuff[index, index1]=DatabaseFieldCodesStuff.LocalFieldCode;
                StoredStuff[index, index1 + 1]=DatabaseFieldCodesStuff.LocalFieldCodeDescription;
                Save.Enabled = true;
            }
            FillDataBaseGrid();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int index, index1;
            
            if (DatabaseGrid.SelectedItems.Count != 1)
                return;

            ComboboxItem comboitem = new ComboboxItem();

            comboitem = (ComboboxItem)Fields.Items[Fields.SelectedIndex];
            index = (int)comboitem.Value;
            
            ListViewItem item = DatabaseGrid.SelectedItems[0];
            index1=(int) item.Tag;

            if (MessageBox.Show("Are You Sure You want to delete the Field documentation '" + StoredStuff[index, index1] + "' " + StoredStuff[index, index1 + 1], "Documentation Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                StoredStuff[index, index1] = null;
                StoredStuff[index, index1+1] = null;
                Save.Enabled = true;
                FillDataBaseGrid();

            }

        }

        private void DatabaseFieldsGrid_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Save.Enabled)
            {
                if (MessageBox.Show("Are You Sure You want to leave without saving the changes", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
