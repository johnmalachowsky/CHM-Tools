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
    public partial class PluginCommandsGrid : Form
    {
        static public int PluginRequestDataCounter = 0;
        static public PluginRequestDataStruct[] PluginRequestData;
        string FileToUse;
        bool Changed = false;
        int ColumnSorted = 0;


        public struct PluginRequestDataStruct
        {
            public bool New;
            public string FileName;
            public string SerialNumber;
            public string CommandNumber;
            public string CommandName;
            public string Comments;
            public bool Save;
            //Data
            public string b1;
            public string b2;
            public string s1;
            public string s2;
            public string i1;
            public string i2;
            public string d1;
            public string d2;
            public string c1;
            public string c2;
            public string c3;
            public string c4;
            public string Strings;
            public string Integers;
            public string OBJ;
        }

        public PluginCommandsGrid()
        {
            InitializeComponent();
        }

        private void PluginCommansGrid_Shown(object sender, EventArgs e)
        {
            PluginRequestData = new PluginRequestDataStruct[99];

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(@"PluginCommands");

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
            if (!File.Exists(FileToUse))
            {
                PluginRequestDataStruct NewPluginDataStruct = new PluginRequestDataStruct();
                NewPluginDataStruct.FileName = FileToUse;
                NewPluginDataStruct.New = true;
                PluginCommands PluginCommandsForm = new PluginCommands(NewPluginDataStruct);
                PluginCommandsForm.ShowDialog();

            }
            XmlDocument Data = new XmlDocument();
            XmlNode DataNode = Data.CreateXmlDeclaration("1.0", "UTF-8", null);
            Data.AppendChild(DataNode);

            XmlNode DataNodeRoot;
            XmlNode DataNodeNode;

            DataNodeRoot = Data.CreateElement("PluginCommandsDocumentation");
            Data.AppendChild(DataNodeRoot);

            DataNodeNode = Data.CreateElement("LastPath");
            DataNodeNode.AppendChild(Data.CreateTextNode(Path.GetDirectoryName(FileToUse)));
            DataNodeRoot.AppendChild(DataNodeNode);
            Data.Save("PluginCommands");

  
            MainListView.Columns.Add("Command Number", -2, HorizontalAlignment.Left);
            MainListView.Columns.Add("Command Name", -2, HorizontalAlignment.Left);
            MainListView.Columns.Add("Comments", -2, HorizontalAlignment.Left);

            LoadandProcessDocumentation();
            SortColumns(ColumnSorted);
            Save.Enabled = false;


        }

        private void LoadandProcessDocumentation()
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(@FileToUse);
            PluginName.Text = Path.GetFileNameWithoutExtension(@FileToUse);

            try
            {
                PluginID.Text = doc.DocumentElement.Attributes.GetNamedItem("SerialNumber").Value;

            }
            catch
            {
                PluginID.Text = "";

            }



            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                foreach (XmlNode Cnode in node)
                {
                    switch (Cnode.Name)
                    {
                        case "CommandNumber":
                            PluginRequestData[PluginRequestDataCounter].CommandNumber = Cnode.InnerText;
                            break;

                        case "CommandName":
                            PluginRequestData[PluginRequestDataCounter].CommandName = Cnode.InnerText;
                            break;

                        case "Comments":
                            PluginRequestData[PluginRequestDataCounter].Comments = Cnode.InnerText;
                            break;

                        case "String-S1":
                            PluginRequestData[PluginRequestDataCounter].s1 = Cnode.InnerText;
                            break;

                        case "String-S2":
                            PluginRequestData[PluginRequestDataCounter].s2 = Cnode.InnerText;
                            break;

                        case "Bool-B1":
                            PluginRequestData[PluginRequestDataCounter].b1 = Cnode.InnerText;
                            break;

                        case "Bool-B2":
                            PluginRequestData[PluginRequestDataCounter].b2 = Cnode.InnerText;
                            break;

                        case "Integer-I1":
                            PluginRequestData[PluginRequestDataCounter].i1 = Cnode.InnerText;
                            break;

                        case "Integer-I2":
                            PluginRequestData[PluginRequestDataCounter].i2 = Cnode.InnerText;
                            break;

                        case "Double-D1":
                            PluginRequestData[PluginRequestDataCounter].d1 = Cnode.InnerText;
                            break;

                        case "Double-D2":
                            PluginRequestData[PluginRequestDataCounter].d2 = Cnode.InnerText;
                            break;

                        case "Characters-C1":
                            PluginRequestData[PluginRequestDataCounter].c1 = Cnode.InnerText;
                            break;

                        case "Characters-C2":
                            PluginRequestData[PluginRequestDataCounter].c2 = Cnode.InnerText;
                            break;

                        case "Characters-C3":
                            PluginRequestData[PluginRequestDataCounter].c3 = Cnode.InnerText;
                            break;

                        case "Characters-C4":
                            PluginRequestData[PluginRequestDataCounter].c4 = Cnode.InnerText;
                            break;

                        case "StringArray":
                            PluginRequestData[PluginRequestDataCounter].Strings = Cnode.InnerText;
                            break;

                        case "IntegerArray":
                            PluginRequestData[PluginRequestDataCounter].Integers = Cnode.InnerText;
                            break;

                        case "Object":
                            PluginRequestData[PluginRequestDataCounter].OBJ = Cnode.InnerText;
                            break;
                    }
                }
                PluginRequestDataCounter++;

            }
        }

        private void FillListView()
        {
            int i;
            ListViewItem item;

            MainListView.Items.Clear();
            for (i = 0; i < PluginRequestDataCounter; i++)
            {
                item = MainListView.Items.Add(string.Format("{0,6}", Convert.ToInt32(PluginRequestData[i].CommandNumber)));
                item.SubItems.Add(PluginRequestData[i].CommandName);
                item.SubItems.Add(PluginRequestData[i].Comments);
                item.Tag = i;

                //MainListView.Items[item.Index].SubItems.Add(PluginRequestData[i].CommandName);
                //MainListView.Items[item.Index].SubItems.Add(PluginRequestData[i].Comments);
            }
            MainListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


        }


        private void NumberSort_Click(object sender, EventArgs e)
        {
        }

        private void NameSort_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            PluginRequestDataStruct NewPluginDataStruct = new PluginRequestDataStruct();
            NewPluginDataStruct.FileName = FileToUse;
            NewPluginDataStruct.SerialNumber = PluginID.Text;
            PluginCommands PluginCommandsForm = new PluginCommands(NewPluginDataStruct);
            PluginCommandsForm.ShowDialog();
            NewPluginDataStruct = PluginCommandsForm.PluginRequestData;
            if (NewPluginDataStruct.Save)
            {
                PluginRequestData[PluginRequestDataCounter] = NewPluginDataStruct;
                PluginRequestDataCounter++;
                SortColumns(ColumnSorted);
                Save.Enabled = true;
                Changed = true;
            }
        }

        private void MainListView_DoubleClick(object sender, EventArgs e)
        {
            PluginRequestDataStruct NewPluginDataStruct = new PluginRequestDataStruct();
            ListViewItem item = MainListView.SelectedItems[0];
            NewPluginDataStruct = PluginRequestData[(int)item.Tag];
            NewPluginDataStruct.FileName = FileToUse;
            NewPluginDataStruct.SerialNumber = PluginID.Text;
            NewPluginDataStruct.New = false;

            PluginCommands PluginCommandsForm = new PluginCommands(NewPluginDataStruct);
            PluginCommandsForm.ShowDialog();
            NewPluginDataStruct = PluginCommandsForm.PluginRequestData;
            if (NewPluginDataStruct.Save)
            {
                PluginRequestData[(int)item.Tag] = NewPluginDataStruct;
                SortColumns(ColumnSorted);
                Save.Enabled = true;
                Changed = true;
            }


        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (MainListView.SelectedItems.Count != 1)
                return;

            ListViewItem item = MainListView.SelectedItems[0];

            if (MessageBox.Show("Are You Sure You want to delete the documentation for Command #" + PluginRequestData[(int)item.Tag].CommandNumber + " '" + PluginRequestData[(int)item.Tag].CommandName + "'", "Documentation Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if ((int)item.Tag == PluginRequestDataCounter - 1)
                    PluginRequestDataCounter--;
                else
                {
                    PluginRequestData[(int)item.Tag] = PluginRequestData[PluginRequestDataCounter - 1];
                    PluginRequestDataCounter--;
                }
                SortColumns(ColumnSorted);
                Save.Enabled = true;
                Changed = true;
            }


        }

        private void Save_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            int index, index2;

            try
            {

                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);

                XmlNode CommandsRoot;
                XmlNode CommandNode;
                XmlNode CommandInfoNode;

                CommandsRoot = doc.CreateElement(PluginName.Text);
                XmlAttribute CommandsSerial = doc.CreateAttribute("SerialNumber");
                CommandsSerial.Value = PluginID.Text;
                CommandsRoot.Attributes.Append(CommandsSerial);
                doc.AppendChild(CommandsRoot);


                for (index = 0; index < PluginRequestDataCounter; index++)
                {
                    CommandNode = doc.CreateElement("PluginCommandInformation");
                    CommandsRoot.AppendChild(CommandNode);

                    CommandInfoNode = doc.CreateElement("CommandNumber");
                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].CommandNumber));
                    CommandNode.AppendChild(CommandInfoNode);

                    CommandInfoNode = doc.CreateElement("CommandName");
                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].CommandName));
                    CommandNode.AppendChild(CommandInfoNode);

                    CommandInfoNode = doc.CreateElement("CommandComment");
                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].Comments));
                    CommandNode.AppendChild(CommandInfoNode);


                    for (index2 = 0; index2 < 15; index2++)
                    {
                        switch (index2)
                        {
                            case 0:
                                if(!string.IsNullOrEmpty(PluginRequestData[index].s1))
                                {
                                    CommandInfoNode = doc.CreateElement("String-S1");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].s1));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;

                            case 1:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].s2))
                                {
                                    CommandInfoNode = doc.CreateElement("String-S2");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].s2));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        
                            case 2:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].b1))
                                {
                                    CommandInfoNode = doc.CreateElement("Bool-B1");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].b1));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        
                             case 3:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].b2))
                                {
                                    CommandInfoNode = doc.CreateElement("Bool-B2");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].b2));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        
                           case 4:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].i1))
                                {
                                    CommandInfoNode = doc.CreateElement("Integer-I1");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].i1));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        
                            case 5:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].i2))
                                {
                                    CommandInfoNode = doc.CreateElement("Integer-I2");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].i2));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        
                            case 6:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].d1))
                                {
                                    CommandInfoNode = doc.CreateElement("Double-D1");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].d1));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        
                            case 7:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].d2))
                                {
                                    CommandInfoNode = doc.CreateElement("Double-D2");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].d2));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        
                            case 8:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].c1))
                                {
                                    CommandInfoNode = doc.CreateElement("Characters-C1");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].c1));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        
                            case 9:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].c2))
                                {
                                    CommandInfoNode = doc.CreateElement("Characters-C2");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].c2));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        
                            case 10:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].c3))
                                {
                                    CommandInfoNode = doc.CreateElement("Characters-C3");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].c3));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        
                            case 11:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].c4))
                                {
                                    CommandInfoNode = doc.CreateElement("Characters-C4");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].c4));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        
                            case 12:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].Strings))
                                {
                                    CommandInfoNode = doc.CreateElement("StringArray");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].Strings));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        
                            case 13:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].Integers))
                                {
                                    CommandInfoNode = doc.CreateElement("IntegerArray");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].Integers));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        
                            case 14:
                                if (!string.IsNullOrEmpty(PluginRequestData[index].OBJ))
                                {
                                    CommandInfoNode = doc.CreateElement("Object");
                                    CommandInfoNode.AppendChild(doc.CreateTextNode(PluginRequestData[index].OBJ));
                                    CommandNode.AppendChild(CommandInfoNode);
                                }
                                break;
                        }

                    }
                }
                doc.Save(Path.ChangeExtension(FileToUse, "tmp"));
                try
                {
                    File.Delete(Path.ChangeExtension(FileToUse, "bak"));
                    if (File.Exists(FileToUse))
                    {
                        File.Move(FileToUse, Path.ChangeExtension(FileToUse, "bak"));

                    }
                    File.Move(Path.ChangeExtension(FileToUse, "tmp"), FileToUse);
                    
                }
                catch
                {
                }
                MessageBox.Show(PluginName.Text + " - " + PluginID.Text, "Documentation File Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Save.Enabled = false;
                Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error Updating Plugin Documentation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PluginID_TextChanged(object sender, EventArgs e)
        {
            Save.Enabled = true;
            Changed = true;
         }

        private void MainListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortColumns(e.Column);
            
        }
    
        private void SortColumns(int Which)
        {

            int i;
            int j;
            PluginRequestDataStruct temp = new PluginRequestDataStruct();

            if (Which == 0)
            {

                for (i = (PluginRequestDataCounter - 1); i >= 0; i--)
                {
                    for (j = 1; j <= i; j++)
                    {
                        if (Convert.ToInt32(PluginRequestData[j - 1].CommandNumber) > Convert.ToInt32(PluginRequestData[j].CommandNumber))
                        {
                            temp = PluginRequestData[j - 1];
                            PluginRequestData[j - 1] = PluginRequestData[j];
                            PluginRequestData[j] = temp;
                        }
                    }
                }
                ColumnSorted = 0;
                FillListView();
            }

            if (Which==1)
            {
                for (i = (PluginRequestDataCounter - 1); i >= 0; i--)
                {
                    for (j = 1; j <= i; j++)
                    {
                        if (string.Compare(PluginRequestData[j - 1].CommandName.ToLower(), PluginRequestData[j].CommandName.ToLower()) > 0)
                        {
                            temp = PluginRequestData[j - 1];
                            PluginRequestData[j - 1] = PluginRequestData[j];
                            PluginRequestData[j] = temp;
                        }
                    }
                }
                ColumnSorted = 1;
                FillListView();
            }
        }

        private void PluginCommandsGrid_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Save.Enabled)
            {
                if (MessageBox.Show("Are You Sure You want to leave without saving the changes", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
 
        }
    }
}
