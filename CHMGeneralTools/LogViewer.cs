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
    public partial class LogViewer : Form
    {
        string FileToUse;
        string Heading;
        string Mask;

        
        public LogViewer(string _Heading, string _Mask)
        {
            InitializeComponent();
            Heading = _Heading;
            Mask = _Mask;
            this.Text = Heading;


        }

        private void LogViewer_Shown(object sender, EventArgs e)
        {
            string line;

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(@"Logs");

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


            openFileDialog1.FileName = "";
            openFileDialog1.Filter = Mask;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK)
            {
                Close();
                return;
            }
            FileToUse = openFileDialog1.FileName;
            XmlDocument Data = new XmlDocument();
            XmlNode DataNode = Data.CreateXmlDeclaration("1.0", "UTF-8", null);
            Data.AppendChild(DataNode);

            XmlNode DataNodeRoot;
            XmlNode DataNodeNode;

            DataNodeRoot = Data.CreateElement("Logs");
            Data.AppendChild(DataNodeRoot);

            DataNodeNode = Data.CreateElement("LastPath");
            DataNodeNode.AppendChild(Data.CreateTextNode(Path.GetDirectoryName(FileToUse)));
            DataNodeRoot.AppendChild(DataNodeNode);
            Data.Save("Logs");

            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(FileToUse);
                while ((line = file.ReadLine()) != null)
                {
                    LogListBox.Items.Add(line);
                }
                file.Close();
            }
            finally
            {
                LogListBox.SelectedIndex = 0;
                this.Text = this.Text + " - " + Path.GetFileNameWithoutExtension(@FileToUse);
            }
        }

        private void FindAllOfMyString(string searchString)
        {
            for (int i = LogListBox.SelectedIndex+1; i < LogListBox.Items.Count; i++)
            {
                if (LogListBox.Items[i].ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    LogListBox.SelectedIndex=i;
                    return;
                }
             }

            for (int i = 0; i < LogListBox.SelectedIndex; i++)
            {
                if (LogListBox.Items[i].ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    LogListBox.SelectedIndex = i;
                    return;
                }
            }

        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(SearchValue.Text))
                return;
            FindAllOfMyString(SearchValue.Text);
        }
    }
}
