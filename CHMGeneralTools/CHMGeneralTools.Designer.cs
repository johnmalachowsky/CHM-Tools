namespace ProgrammingTools
{
    partial class CHMGeneralTools
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainFormMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devicesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.specialPluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemDataLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flagLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemDataLogsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.flagLogsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.messageLogsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.errorLogsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptStartupFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginCommandDocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseFieldDocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.MainFormMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormMenu
            // 
            this.MainFormMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataBaseToolStripMenuItem,
            this.objectsToolStripMenuItem,
            this.logsToolStripMenuItem,
            this.encryptionToolStripMenuItem,
            this.documentationToolStripMenuItem});
            this.MainFormMenu.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenu.Name = "MainFormMenu";
            this.MainFormMenu.Size = new System.Drawing.Size(837, 24);
            this.MainFormMenu.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dataBaseToolStripMenuItem
            // 
            this.dataBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationInformationToolStripMenuItem});
            this.dataBaseToolStripMenuItem.Name = "dataBaseToolStripMenuItem";
            this.dataBaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.dataBaseToolStripMenuItem.Text = "DataBase";
            // 
            // configurationInformationToolStripMenuItem
            // 
            this.configurationInformationToolStripMenuItem.Name = "configurationInformationToolStripMenuItem";
            this.configurationInformationToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.configurationInformationToolStripMenuItem.Text = "Configuration Information";
            this.configurationInformationToolStripMenuItem.Click += new System.EventHandler(this.configurationInformationToolStripMenuItem_Click);
            // 
            // objectsToolStripMenuItem
            // 
            this.objectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomsToolStripMenuItem,
            this.devicesToolStripMenuItem,
            this.devicesToolStripMenuItem1,
            this.specialPluginsToolStripMenuItem});
            this.objectsToolStripMenuItem.Name = "objectsToolStripMenuItem";
            this.objectsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.objectsToolStripMenuItem.Text = "Objects";
            // 
            // roomsToolStripMenuItem
            // 
            this.roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
            this.roomsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.roomsToolStripMenuItem.Text = "Rooms";
            this.roomsToolStripMenuItem.Click += new System.EventHandler(this.roomsToolStripMenuItem_Click);
            // 
            // devicesToolStripMenuItem
            // 
            this.devicesToolStripMenuItem.Name = "devicesToolStripMenuItem";
            this.devicesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.devicesToolStripMenuItem.Text = "Interfaces";
            this.devicesToolStripMenuItem.Click += new System.EventHandler(this.devicesToolStripMenuItem_Click);
            // 
            // devicesToolStripMenuItem1
            // 
            this.devicesToolStripMenuItem1.Name = "devicesToolStripMenuItem1";
            this.devicesToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.devicesToolStripMenuItem1.Text = "Devices";
            this.devicesToolStripMenuItem1.Click += new System.EventHandler(this.devicesToolStripMenuItem1_Click);
            // 
            // specialPluginsToolStripMenuItem
            // 
            this.specialPluginsToolStripMenuItem.Name = "specialPluginsToolStripMenuItem";
            this.specialPluginsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.specialPluginsToolStripMenuItem.Text = "Special Plugins";
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startupLogsToolStripMenuItem,
            this.finalLogsToolStripMenuItem});
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.logsToolStripMenuItem.Text = "Logs";
            // 
            // startupLogsToolStripMenuItem
            // 
            this.startupLogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemDataLogsToolStripMenuItem,
            this.flagLogsToolStripMenuItem,
            this.messageLogsToolStripMenuItem,
            this.errorLogsToolStripMenuItem});
            this.startupLogsToolStripMenuItem.Name = "startupLogsToolStripMenuItem";
            this.startupLogsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.startupLogsToolStripMenuItem.Text = "Startup Logs";
            // 
            // systemDataLogsToolStripMenuItem
            // 
            this.systemDataLogsToolStripMenuItem.Name = "systemDataLogsToolStripMenuItem";
            this.systemDataLogsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.systemDataLogsToolStripMenuItem.Text = "System Data Logs";
            this.systemDataLogsToolStripMenuItem.Click += new System.EventHandler(this.systemDataLogsToolStripMenuItem_Click);
            // 
            // flagLogsToolStripMenuItem
            // 
            this.flagLogsToolStripMenuItem.Name = "flagLogsToolStripMenuItem";
            this.flagLogsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.flagLogsToolStripMenuItem.Text = "Flag Logs";
            this.flagLogsToolStripMenuItem.Click += new System.EventHandler(this.flagLogsToolStripMenuItem_Click);
            // 
            // messageLogsToolStripMenuItem
            // 
            this.messageLogsToolStripMenuItem.Name = "messageLogsToolStripMenuItem";
            this.messageLogsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.messageLogsToolStripMenuItem.Text = "Message Logs";
            this.messageLogsToolStripMenuItem.Click += new System.EventHandler(this.messageLogsToolStripMenuItem_Click);
            // 
            // errorLogsToolStripMenuItem
            // 
            this.errorLogsToolStripMenuItem.Name = "errorLogsToolStripMenuItem";
            this.errorLogsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.errorLogsToolStripMenuItem.Text = "Error Logs";
            this.errorLogsToolStripMenuItem.Click += new System.EventHandler(this.errorLogsToolStripMenuItem_Click);
            // 
            // finalLogsToolStripMenuItem
            // 
            this.finalLogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemDataLogsToolStripMenuItem1,
            this.flagLogsToolStripMenuItem1,
            this.messageLogsToolStripMenuItem1,
            this.errorLogsToolStripMenuItem1});
            this.finalLogsToolStripMenuItem.Name = "finalLogsToolStripMenuItem";
            this.finalLogsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.finalLogsToolStripMenuItem.Text = "Final Logs";
            // 
            // systemDataLogsToolStripMenuItem1
            // 
            this.systemDataLogsToolStripMenuItem1.Name = "systemDataLogsToolStripMenuItem1";
            this.systemDataLogsToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.systemDataLogsToolStripMenuItem1.Text = "System Data Logs";
            this.systemDataLogsToolStripMenuItem1.Click += new System.EventHandler(this.systemDataLogsToolStripMenuItem1_Click);
            // 
            // flagLogsToolStripMenuItem1
            // 
            this.flagLogsToolStripMenuItem1.Name = "flagLogsToolStripMenuItem1";
            this.flagLogsToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.flagLogsToolStripMenuItem1.Text = "Flag Logs";
            this.flagLogsToolStripMenuItem1.Click += new System.EventHandler(this.flagLogsToolStripMenuItem1_Click);
            // 
            // messageLogsToolStripMenuItem1
            // 
            this.messageLogsToolStripMenuItem1.Name = "messageLogsToolStripMenuItem1";
            this.messageLogsToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.messageLogsToolStripMenuItem1.Text = "Message Logs";
            this.messageLogsToolStripMenuItem1.Click += new System.EventHandler(this.messageLogsToolStripMenuItem1_Click);
            // 
            // errorLogsToolStripMenuItem1
            // 
            this.errorLogsToolStripMenuItem1.Name = "errorLogsToolStripMenuItem1";
            this.errorLogsToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.errorLogsToolStripMenuItem1.Text = "Error Logs";
            this.errorLogsToolStripMenuItem1.Click += new System.EventHandler(this.errorLogsToolStripMenuItem1_Click);
            // 
            // encryptionToolStripMenuItem
            // 
            this.encryptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encryptStartupFileToolStripMenuItem});
            this.encryptionToolStripMenuItem.Name = "encryptionToolStripMenuItem";
            this.encryptionToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.encryptionToolStripMenuItem.Text = "Encryption";
            // 
            // encryptStartupFileToolStripMenuItem
            // 
            this.encryptStartupFileToolStripMenuItem.Name = "encryptStartupFileToolStripMenuItem";
            this.encryptStartupFileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.encryptStartupFileToolStripMenuItem.Text = "Encrypt Startup File";
            this.encryptStartupFileToolStripMenuItem.Click += new System.EventHandler(this.encryptStartupFileToolStripMenuItem_Click);
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginCommandDocumentationToolStripMenuItem,
            this.databaseFieldDocumentationToolStripMenuItem});
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(179, 20);
            this.documentationToolStripMenuItem.Text = "Programming Documentation";
            // 
            // pluginCommandDocumentationToolStripMenuItem
            // 
            this.pluginCommandDocumentationToolStripMenuItem.Name = "pluginCommandDocumentationToolStripMenuItem";
            this.pluginCommandDocumentationToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.pluginCommandDocumentationToolStripMenuItem.Text = "Plugin Commands";
            this.pluginCommandDocumentationToolStripMenuItem.Click += new System.EventHandler(this.pluginCommandDocumentationToolStripMenuItem_Click);
            // 
            // databaseFieldDocumentationToolStripMenuItem
            // 
            this.databaseFieldDocumentationToolStripMenuItem.Name = "databaseFieldDocumentationToolStripMenuItem";
            this.databaseFieldDocumentationToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.databaseFieldDocumentationToolStripMenuItem.Text = "Database Fields";
            this.databaseFieldDocumentationToolStripMenuItem.Click += new System.EventHandler(this.databaseFieldDocumentationToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "CHMDatabase.3db";
            this.openFileDialog1.Filter = " CHM Main Database |CHMDatabase.3db";
            // 
            // CHMGeneralTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 262);
            this.Controls.Add(this.MainFormMenu);
            this.MainMenuStrip = this.MainFormMenu;
            this.Name = "CHMGeneralTools";
            this.Text = "Centurion Home Monitor General Tools";
            this.MainFormMenu.ResumeLayout(false);
            this.MainFormMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainFormMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginCommandDocumentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseFieldDocumentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemDataLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flagLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemDataLogsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem flagLogsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem messageLogsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem errorLogsToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem devicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devicesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem specialPluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encryptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encryptStartupFileToolStripMenuItem;
    }
}

