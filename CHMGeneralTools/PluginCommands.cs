using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;


namespace ProgrammingTools
{
    public partial class PluginCommands : Form
    {
        public PluginCommandsGrid.PluginRequestDataStruct PluginRequestData;

        public PluginCommands(PluginCommandsGrid.PluginRequestDataStruct PID)
        {
            InitializeComponent();
            PluginRequestData =PID;


        }

        private void PluginCommands_Shown(object sender, EventArgs e)
        {
            if (PluginRequestData.New)
            {
                PluginName.ReadOnly = false;
                PluginID.ReadOnly = false;
                PluginName.Text = Path.GetFileNameWithoutExtension(@PluginRequestData.FileName);
                Create.Visible = true;
                Cancel.Visible = true;
                Create.Text = "Create Documentation";
                Cancel.Text = "Cancel Creation";
                DataPanel.Visible = false;
            }
            else
            {
                PluginName.ReadOnly = true;
                PluginID.ReadOnly = true;
                PluginName.Text = Path.GetFileNameWithoutExtension(@PluginRequestData.FileName);
                PluginName.TabStop = false;
                PluginID.TabStop = false;
                PluginID.Text = PluginRequestData.SerialNumber;
                Create.Visible = false;
                Cancel.Visible = true;
                Save.Visible = true;
                Cancel.Text = "Cancel";
                PluginRequestData.Save = false;
                DataPanel.Visible = true; ;
                CommandNumber.Focus();
            }
            FillTheScreen();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            //create and save new file
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);

                XmlElement rootNode = xmlDoc.CreateElement(PluginName.Text);
                rootNode.SetAttribute("SerialNumber", PluginID.Text);
                xmlDoc.AppendChild(rootNode);

                // Create a new <Category> element and add it to the root node
                XmlElement parentNode = xmlDoc.CreateElement("PluginCommandInformation");
                xmlDoc.DocumentElement.PrependChild(parentNode);


                //// Create the required nodes
                //XmlElement CommandNameNode = xmlDoc.CreateElement("CommandName");
                //XmlText CommandNameText = xmlDoc.CreateTextNode("Plugin To Send Received Data To");
                //parentNode.AppendChild(CommandNameNode);
                //CommandNameNode.AppendChild(CommandNameText);


                //XmlElement CommandNumberNode = xmlDoc.CreateElement("CommandNumber");
                //XmlText CommandNumberText = xmlDoc.CreateTextNode("1");
                //parentNode.AppendChild(CommandNumberNode);
                //CommandNumberNode.AppendChild(CommandNumberText);


                xmlDoc.Save(PluginRequestData.FileName);
                MessageBox.Show(PluginName.Text + " - " + PluginID.Text, "Documentation File Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error Creating Plugin Documentation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            PluginRequestData.Save = false;
            Close();
        }



        private void FillTheScreen()
        {
            B1.Text = PluginRequestData.b1;
            B2.Text = PluginRequestData.b2;
            I1.Text = PluginRequestData.i1;
            I2.Text = PluginRequestData.i2;
            S1.Text = PluginRequestData.s1;
            S2.Text = PluginRequestData.s2;
            D1.Text = PluginRequestData.d1;
            D2.Text = PluginRequestData.d2;
            C1.Text = PluginRequestData.c1;
            C2.Text = PluginRequestData.c2;
            C3.Text = PluginRequestData.c3;
            C4.Text = PluginRequestData.c4
                ;
            Strings.Text = PluginRequestData.Strings;
            Integers.Text = PluginRequestData.Integers;
            O1.Text = PluginRequestData.OBJ;
            Comments.Text = PluginRequestData.Comments;
            CommandNumber.Text = PluginRequestData.CommandNumber;
            CommandName.Text = PluginRequestData.CommandName;

            Save.Enabled = false;
        }

        private void SaveDataFromScreen()
        {
            PluginRequestData.b1 = B1.Text.Trim();
            PluginRequestData.b1 = B1.Text.Trim();
            PluginRequestData.b2 = B2.Text.Trim();
            PluginRequestData.i1 = I1.Text.Trim();
            PluginRequestData.i2 = I2.Text.Trim();
            PluginRequestData.s1 = S1.Text.Trim();
            PluginRequestData.s2 = S2.Text.Trim();
            PluginRequestData.d1 = D1.Text.Trim();
            PluginRequestData.d2 = D2.Text.Trim();
            PluginRequestData.c1 = C1.Text.Trim();
            PluginRequestData.c2 = C2.Text.Trim();
            PluginRequestData.c3 = C3.Text.Trim();
            PluginRequestData.c4 = C4.Text.Trim();
            PluginRequestData.Strings = Strings.Text.Trim();
            PluginRequestData.Integers = Integers.Text.Trim();
            PluginRequestData.OBJ = O1.Text.Trim();
            PluginRequestData.Comments = Comments.Text.Trim();
            PluginRequestData.CommandName = CommandName.Text.Trim();
            PluginRequestData.CommandNumber = CommandNumber.Text.Trim();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PluginCommandsGrid.PluginRequestDataCounter; i++)
            {
                if (Convert.ToInt32(CommandNumber.Text.Trim()) == Convert.ToInt32(PluginCommandsGrid.PluginRequestData[i].CommandNumber) || CommandNumber.Text == PluginCommandsGrid.PluginRequestData[i].CommandNumber)
                {
                    MessageBox.Show("Duplicate Command Number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                
                }

            }

            SaveDataFromScreen();
            PluginRequestData.Save = true;
            Close();

        }

        private void CommandNumber_TextChanged(object sender, EventArgs e)
        {
            Save.Enabled = true;
        }
    }
}
