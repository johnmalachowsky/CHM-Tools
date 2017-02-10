namespace ProgrammingTools
{
    partial class PluginCommands
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PluginName = new System.Windows.Forms.TextBox();
            this.PluginID = new System.Windows.Forms.MaskedTextBox();
            this.Create = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.DataPanel = new System.Windows.Forms.Panel();
            this.CommandName = new System.Windows.Forms.TextBox();
            this.CommandNumber = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.O1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.Comments = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.D2 = new System.Windows.Forms.TextBox();
            this.D1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.I2 = new System.Windows.Forms.TextBox();
            this.I1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Integers = new System.Windows.Forms.TextBox();
            this.Strings = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.S2 = new System.Windows.Forms.TextBox();
            this.S1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.B2 = new System.Windows.Forms.TextBox();
            this.B1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.C2 = new System.Windows.Forms.TextBox();
            this.C1 = new System.Windows.Forms.TextBox();
            this.C4 = new System.Windows.Forms.TextBox();
            this.C3 = new System.Windows.Forms.TextBox();
            this.DataPanel.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plugin Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Plugin ID:";
            // 
            // PluginName
            // 
            this.PluginName.Location = new System.Drawing.Point(102, 20);
            this.PluginName.Name = "PluginName";
            this.PluginName.ReadOnly = true;
            this.PluginName.Size = new System.Drawing.Size(162, 20);
            this.PluginName.TabIndex = 0;
            // 
            // PluginID
            // 
            this.PluginID.Location = new System.Drawing.Point(380, 20);
            this.PluginID.Mask = "00000-00000";
            this.PluginID.Name = "PluginID";
            this.PluginID.ReadOnly = true;
            this.PluginID.Size = new System.Drawing.Size(73, 20);
            this.PluginID.TabIndex = 1;
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(481, 18);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(125, 22);
            this.Create.TabIndex = 3;
            this.Create.Text = "Create Documentation";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Visible = false;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(747, 18);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(125, 22);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Cancel Creation";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Visible = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // DataPanel
            // 
            this.DataPanel.Controls.Add(this.groupBox7);
            this.DataPanel.Controls.Add(this.CommandName);
            this.DataPanel.Controls.Add(this.CommandNumber);
            this.DataPanel.Controls.Add(this.groupBox6);
            this.DataPanel.Controls.Add(this.Comments);
            this.DataPanel.Controls.Add(this.label15);
            this.DataPanel.Controls.Add(this.groupBox4);
            this.DataPanel.Controls.Add(this.groupBox3);
            this.DataPanel.Controls.Add(this.groupBox5);
            this.DataPanel.Controls.Add(this.groupBox2);
            this.DataPanel.Controls.Add(this.groupBox1);
            this.DataPanel.Controls.Add(this.label4);
            this.DataPanel.Controls.Add(this.label3);
            this.DataPanel.Location = new System.Drawing.Point(10, 57);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.Size = new System.Drawing.Size(1000, 420);
            this.DataPanel.TabIndex = 2;
            // 
            // CommandName
            // 
            this.CommandName.Location = new System.Drawing.Point(259, 16);
            this.CommandName.Name = "CommandName";
            this.CommandName.Size = new System.Drawing.Size(237, 20);
            this.CommandName.TabIndex = 2;
            this.CommandName.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // CommandNumber
            // 
            this.CommandNumber.Location = new System.Drawing.Point(116, 16);
            this.CommandNumber.Name = "CommandNumber";
            this.CommandNumber.Size = new System.Drawing.Size(41, 20);
            this.CommandNumber.TabIndex = 1;
            this.CommandNumber.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.O1);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Location = new System.Drawing.Point(9, 351);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(481, 62);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Objects";
            // 
            // O1
            // 
            this.O1.Location = new System.Drawing.Point(29, 27);
            this.O1.Name = "O1";
            this.O1.Size = new System.Drawing.Size(445, 20);
            this.O1.TabIndex = 0;
            this.O1.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 30);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "O1";
            // 
            // Comments
            // 
            this.Comments.Location = new System.Drawing.Point(572, 18);
            this.Comments.Multiline = true;
            this.Comments.Name = "Comments";
            this.Comments.Size = new System.Drawing.Size(347, 20);
            this.Comments.TabIndex = 3;
            this.Comments.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(507, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Comments:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.D2);
            this.groupBox4.Controls.Add(this.D1);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(505, 173);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(486, 77);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Double Values";
            // 
            // D2
            // 
            this.D2.Location = new System.Drawing.Point(33, 51);
            this.D2.Name = "D2";
            this.D2.Size = new System.Drawing.Size(447, 20);
            this.D2.TabIndex = 1;
            this.D2.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // D1
            // 
            this.D1.Location = new System.Drawing.Point(33, 27);
            this.D1.Name = "D1";
            this.D1.Size = new System.Drawing.Size(447, 20);
            this.D1.TabIndex = 0;
            this.D1.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "D2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "D1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.I2);
            this.groupBox3.Controls.Add(this.I1);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(5, 173);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(485, 77);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Integer Values";
            // 
            // I2
            // 
            this.I2.Location = new System.Drawing.Point(26, 51);
            this.I2.Name = "I2";
            this.I2.Size = new System.Drawing.Size(447, 20);
            this.I2.TabIndex = 1;
            this.I2.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // I1
            // 
            this.I1.Location = new System.Drawing.Point(28, 27);
            this.I1.Name = "I1";
            this.I1.Size = new System.Drawing.Size(447, 20);
            this.I1.TabIndex = 0;
            this.I1.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "I2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "I1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Integers);
            this.groupBox5.Controls.Add(this.Strings);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(6, 271);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(484, 74);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Array Values";
            // 
            // Integers
            // 
            this.Integers.Location = new System.Drawing.Point(69, 45);
            this.Integers.Name = "Integers";
            this.Integers.Size = new System.Drawing.Size(407, 20);
            this.Integers.TabIndex = 2;
            this.Integers.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // Strings
            // 
            this.Strings.Location = new System.Drawing.Point(69, 19);
            this.Strings.Name = "Strings";
            this.Strings.Size = new System.Drawing.Size(407, 20);
            this.Strings.TabIndex = 1;
            this.Strings.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Integers:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Strings:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.S2);
            this.groupBox2.Controls.Add(this.S1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(505, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 77);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "String Values";
            // 
            // S2
            // 
            this.S2.Location = new System.Drawing.Point(33, 50);
            this.S2.Name = "S2";
            this.S2.Size = new System.Drawing.Size(447, 20);
            this.S2.TabIndex = 1;
            this.S2.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // S1
            // 
            this.S1.Location = new System.Drawing.Point(33, 26);
            this.S1.Name = "S1";
            this.S1.Size = new System.Drawing.Size(447, 20);
            this.S1.TabIndex = 0;
            this.S1.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "S2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "S1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.B2);
            this.groupBox1.Controls.Add(this.B1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(5, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 77);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Boolean Values";
            // 
            // B2
            // 
            this.B2.Location = new System.Drawing.Point(32, 51);
            this.B2.Name = "B2";
            this.B2.Size = new System.Drawing.Size(447, 20);
            this.B2.TabIndex = 1;
            this.B2.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // B1
            // 
            this.B1.Location = new System.Drawing.Point(32, 27);
            this.B1.Name = "B1";
            this.B1.Size = new System.Drawing.Size(447, 20);
            this.B1.TabIndex = 0;
            this.B1.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "B2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "B1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Command Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Command Number:";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(614, 18);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(125, 22);
            this.Save.TabIndex = 4;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Visible = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.C4);
            this.groupBox7.Controls.Add(this.C3);
            this.groupBox7.Controls.Add(this.C2);
            this.groupBox7.Controls.Add(this.C1);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Location = new System.Drawing.Point(505, 271);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(486, 123);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Characters";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "C1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 13);
            this.label17.TabIndex = 12;
            this.label17.Text = "C2";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1, 70);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 13);
            this.label19.TabIndex = 13;
            this.label19.Text = "C3";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(1, 93);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 13);
            this.label20.TabIndex = 14;
            this.label20.Text = "C4";
            // 
            // C2
            // 
            this.C2.Location = new System.Drawing.Point(26, 40);
            this.C2.Name = "C2";
            this.C2.Size = new System.Drawing.Size(447, 20);
            this.C2.TabIndex = 16;
            this.C2.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // C1
            // 
            this.C1.Location = new System.Drawing.Point(26, 16);
            this.C1.Name = "C1";
            this.C1.Size = new System.Drawing.Size(447, 20);
            this.C1.TabIndex = 15;
            this.C1.TextChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // C4
            // 
            this.C4.Location = new System.Drawing.Point(26, 90);
            this.C4.Name = "C4";
            this.C4.Size = new System.Drawing.Size(447, 20);
            this.C4.TabIndex = 18;
            this.C4.TextAlignChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // C3
            // 
            this.C3.Location = new System.Drawing.Point(26, 66);
            this.C3.Name = "C3";
            this.C3.Size = new System.Drawing.Size(447, 20);
            this.C3.TabIndex = 17;
            this.C3.TextAlignChanged += new System.EventHandler(this.CommandNumber_TextChanged);
            // 
            // PluginCommands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 507);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.DataPanel);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.PluginID);
            this.Controls.Add(this.PluginName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(1028, 600);
            this.Name = "PluginCommands";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PluginCommands";
            this.Shown += new System.EventHandler(this.PluginCommands_Shown);
            this.DataPanel.ResumeLayout(false);
            this.DataPanel.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PluginName;
        private System.Windows.Forms.MaskedTextBox PluginID;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Panel DataPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox B2;
        private System.Windows.Forms.TextBox B1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox Comments;
        private System.Windows.Forms.TextBox I2;
        private System.Windows.Forms.TextBox I1;
        private System.Windows.Forms.TextBox Integers;
        private System.Windows.Forms.TextBox Strings;
        private System.Windows.Forms.TextBox D2;
        private System.Windows.Forms.TextBox D1;
        private System.Windows.Forms.TextBox S2;
        private System.Windows.Forms.TextBox S1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox O1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox CommandNumber;
        private System.Windows.Forms.TextBox CommandName;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox C4;
        private System.Windows.Forms.TextBox C3;
        private System.Windows.Forms.TextBox C2;
        private System.Windows.Forms.TextBox C1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;

    }
}