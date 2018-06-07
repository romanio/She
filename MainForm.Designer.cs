namespace She
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private OpenTK.GLControl glControl;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Static");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Dynamic");
            this.glControl = new OpenTK.GLControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.boxRestartDate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.treeProperties = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numIcoord = new System.Windows.Forms.NumericUpDown();
            this.numJcoord = new System.Windows.Forms.NumericUpDown();
            this.numKcoord = new System.Windows.Forms.NumericUpDown();
            this.boxMinimum = new System.Windows.Forms.TextBox();
            this.boxMaximum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkICoord = new System.Windows.Forms.CheckBox();
            this.chkJCoord = new System.Windows.Forms.CheckBox();
            this.chkKCoord = new System.Windows.Forms.CheckBox();
            this.chkMinimum = new System.Windows.Forms.CheckBox();
            this.chkMaximum = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIcoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJcoord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKcoord)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.glControl.Location = new System.Drawing.Point(164, 37);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(538, 474);
            this.glControl.TabIndex = 1;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.GlControlLoad);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.GlControlPaint);
            this.glControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GlControlOnMouseMove);
            this.glControl.Resize += new System.EventHandler(this.GlControlResize);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(923, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(295, 17);
            this.toolStripStatusLabel1.Text = "Use Right Mouse Button to Rotate and Middle-Button to Pan";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openModelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(923, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openModelToolStripMenuItem
            // 
            this.openModelToolStripMenuItem.Name = "openModelToolStripMenuItem";
            this.openModelToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.openModelToolStripMenuItem.Text = "Open model";
            this.openModelToolStripMenuItem.Click += new System.EventHandler(this.openModelToolStripMenuItem_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.Filter = "Eclipse file|*.SMSPEC";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(708, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Restart date";
            // 
            // boxRestartDate
            // 
            this.boxRestartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.boxRestartDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxRestartDate.FormattingEnabled = true;
            this.boxRestartDate.Location = new System.Drawing.Point(711, 53);
            this.boxRestartDate.Name = "boxRestartDate";
            this.boxRestartDate.Size = new System.Drawing.Size(121, 21);
            this.boxRestartDate.TabIndex = 5;
            this.boxRestartDate.SelectedIndexChanged += new System.EventHandler(this.boxRestartDate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Properties";
            // 
            // treeProperties
            // 
            this.treeProperties.FullRowSelect = true;
            this.treeProperties.HideSelection = false;
            this.treeProperties.Location = new System.Drawing.Point(17, 63);
            this.treeProperties.Name = "treeProperties";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Static";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Dynamic";
            this.treeProperties.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeProperties.Size = new System.Drawing.Size(141, 348);
            this.treeProperties.TabIndex = 7;
            this.treeProperties.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeProperties_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(711, 113);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 398);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkMaximum);
            this.tabPage1.Controls.Add(this.chkMinimum);
            this.tabPage1.Controls.Add(this.chkKCoord);
            this.tabPage1.Controls.Add(this.chkJCoord);
            this.tabPage1.Controls.Add(this.chkICoord);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.boxMaximum);
            this.tabPage1.Controls.Add(this.boxMinimum);
            this.tabPage1.Controls.Add(this.numKcoord);
            this.tabPage1.Controls.Add(this.numJcoord);
            this.tabPage1.Controls.Add(this.numIcoord);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(192, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Filters";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numIcoord
            // 
            this.numIcoord.Location = new System.Drawing.Point(89, 18);
            this.numIcoord.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numIcoord.Name = "numIcoord";
            this.numIcoord.Size = new System.Drawing.Size(88, 21);
            this.numIcoord.TabIndex = 1;
            this.numIcoord.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numJcoord
            // 
            this.numJcoord.Location = new System.Drawing.Point(89, 45);
            this.numJcoord.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numJcoord.Name = "numJcoord";
            this.numJcoord.Size = new System.Drawing.Size(88, 21);
            this.numJcoord.TabIndex = 3;
            this.numJcoord.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numKcoord
            // 
            this.numKcoord.Location = new System.Drawing.Point(89, 72);
            this.numKcoord.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numKcoord.Name = "numKcoord";
            this.numKcoord.Size = new System.Drawing.Size(88, 21);
            this.numKcoord.TabIndex = 4;
            this.numKcoord.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // boxMinimum
            // 
            this.boxMinimum.Location = new System.Drawing.Point(86, 118);
            this.boxMinimum.Name = "boxMinimum";
            this.boxMinimum.Size = new System.Drawing.Size(91, 21);
            this.boxMinimum.TabIndex = 8;
            // 
            // boxMaximum
            // 
            this.boxMaximum.Location = new System.Drawing.Point(86, 146);
            this.boxMaximum.Name = "boxMaximum";
            this.boxMaximum.Size = new System.Drawing.Size(91, 21);
            this.boxMaximum.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkICoord
            // 
            this.chkICoord.AutoSize = true;
            this.chkICoord.Location = new System.Drawing.Point(6, 19);
            this.chkICoord.Name = "chkICoord";
            this.chkICoord.Size = new System.Drawing.Size(61, 17);
            this.chkICoord.TabIndex = 11;
            this.chkICoord.Text = "I-coord";
            this.chkICoord.UseVisualStyleBackColor = true;
            // 
            // chkJCoord
            // 
            this.chkJCoord.AutoSize = true;
            this.chkJCoord.Location = new System.Drawing.Point(6, 46);
            this.chkJCoord.Name = "chkJCoord";
            this.chkJCoord.Size = new System.Drawing.Size(62, 17);
            this.chkJCoord.TabIndex = 12;
            this.chkJCoord.Text = "J-coord";
            this.chkJCoord.UseVisualStyleBackColor = true;
            // 
            // chkKCoord
            // 
            this.chkKCoord.AutoSize = true;
            this.chkKCoord.Location = new System.Drawing.Point(6, 73);
            this.chkKCoord.Name = "chkKCoord";
            this.chkKCoord.Size = new System.Drawing.Size(63, 17);
            this.chkKCoord.TabIndex = 13;
            this.chkKCoord.Text = "K-coord";
            this.chkKCoord.UseVisualStyleBackColor = true;
            // 
            // chkMinimum
            // 
            this.chkMinimum.AutoSize = true;
            this.chkMinimum.Location = new System.Drawing.Point(6, 120);
            this.chkMinimum.Name = "chkMinimum";
            this.chkMinimum.Size = new System.Drawing.Size(66, 17);
            this.chkMinimum.TabIndex = 14;
            this.chkMinimum.Text = "Minimum";
            this.chkMinimum.UseVisualStyleBackColor = true;
            // 
            // chkMaximum
            // 
            this.chkMaximum.AutoSize = true;
            this.chkMaximum.Location = new System.Drawing.Point(6, 148);
            this.chkMaximum.Name = "chkMaximum";
            this.chkMaximum.Size = new System.Drawing.Size(70, 17);
            this.chkMaximum.TabIndex = 15;
            this.chkMaximum.Text = "Maximum";
            this.chkMaximum.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 557);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeProperties);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.boxRestartDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.glControl);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "She";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIcoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJcoord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKcoord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openModelToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox boxRestartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeProperties;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown numKcoord;
        private System.Windows.Forms.NumericUpDown numJcoord;
        private System.Windows.Forms.NumericUpDown numIcoord;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox boxMaximum;
        private System.Windows.Forms.TextBox boxMinimum;
        private System.Windows.Forms.CheckBox chkMaximum;
        private System.Windows.Forms.CheckBox chkMinimum;
        private System.Windows.Forms.CheckBox chkKCoord;
        private System.Windows.Forms.CheckBox chkJCoord;
        private System.Windows.Forms.CheckBox chkICoord;
    }
}
