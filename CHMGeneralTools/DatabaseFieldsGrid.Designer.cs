namespace ProgrammingTools
{
    partial class DatabaseFieldsGrid
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.DatabaseName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Fields = new System.Windows.Forms.ComboBox();
            this.AddField = new System.Windows.Forms.Button();
            this.DatabaseGrid = new System.Windows.Forms.ListView();
            this.Save = new System.Windows.Forms.Button();
            this.AddFieldCodes = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.DefaultExt = "*.xml";
            this.openFileDialog1.Filter = "XML Files | *.xml";
            this.openFileDialog1.Title = "Which Plugin Do You Wish To Document";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Name";
            // 
            // DatabaseName
            // 
            this.DatabaseName.Location = new System.Drawing.Point(114, 9);
            this.DatabaseName.Name = "DatabaseName";
            this.DatabaseName.ReadOnly = true;
            this.DatabaseName.Size = new System.Drawing.Size(175, 20);
            this.DatabaseName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fields";
            // 
            // Fields
            // 
            this.Fields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Fields.FormattingEnabled = true;
            this.Fields.Location = new System.Drawing.Point(338, 9);
            this.Fields.Name = "Fields";
            this.Fields.Size = new System.Drawing.Size(171, 21);
            this.Fields.TabIndex = 3;
            this.Fields.SelectedIndexChanged += new System.EventHandler(this.Fields_SelectedIndexChanged);
            // 
            // AddField
            // 
            this.AddField.Location = new System.Drawing.Point(559, 53);
            this.AddField.Name = "AddField";
            this.AddField.Size = new System.Drawing.Size(96, 23);
            this.AddField.TabIndex = 4;
            this.AddField.Text = "Add Field";
            this.AddField.UseVisualStyleBackColor = true;
            this.AddField.Click += new System.EventHandler(this.AddField_Click);
            // 
            // DatabaseGrid
            // 
            this.DatabaseGrid.FullRowSelect = true;
            this.DatabaseGrid.Location = new System.Drawing.Point(27, 50);
            this.DatabaseGrid.MultiSelect = false;
            this.DatabaseGrid.Name = "DatabaseGrid";
            this.DatabaseGrid.Size = new System.Drawing.Size(512, 200);
            this.DatabaseGrid.TabIndex = 5;
            this.DatabaseGrid.UseCompatibleStateImageBehavior = false;
            this.DatabaseGrid.View = System.Windows.Forms.View.Details;
            this.DatabaseGrid.DoubleClick += new System.EventHandler(this.DatabaseGrid_DoubleClick);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(559, 175);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(96, 23);
            this.Save.TabIndex = 6;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // AddFieldCodes
            // 
            this.AddFieldCodes.Location = new System.Drawing.Point(559, 91);
            this.AddFieldCodes.Name = "AddFieldCodes";
            this.AddFieldCodes.Size = new System.Drawing.Size(96, 23);
            this.AddFieldCodes.TabIndex = 7;
            this.AddFieldCodes.Text = "Add Field Codes";
            this.AddFieldCodes.UseVisualStyleBackColor = true;
            this.AddFieldCodes.Click += new System.EventHandler(this.AddFieldCodes_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(559, 134);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(96, 23);
            this.Delete.TabIndex = 8;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(558, 215);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(96, 23);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // DatabaseFieldsGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 262);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.AddFieldCodes);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.DatabaseGrid);
            this.Controls.Add(this.AddField);
            this.Controls.Add(this.Fields);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DatabaseName);
            this.Controls.Add(this.label1);
            this.Name = "DatabaseFieldsGrid";
            this.Text = "Database Fields List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseFieldsGrid_FormClosing);
            this.Shown += new System.EventHandler(this.DatabaseFieldsGrid_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DatabaseName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Fields;
        private System.Windows.Forms.Button AddField;
        private System.Windows.Forms.ListView DatabaseGrid;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button AddFieldCodes;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Cancel;
    }
}