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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Static");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Dynamic");
            this.glControl = new OpenTK.GLControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.boxRestartDate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.treeProperties = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numKCto = new System.Windows.Forms.NumericUpDown();
            this.numJCto = new System.Windows.Forms.NumericUpDown();
            this.numICto = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkMaximum = new System.Windows.Forms.CheckBox();
            this.chkMinimum = new System.Windows.Forms.CheckBox();
            this.chkKCoord = new System.Windows.Forms.CheckBox();
            this.chkJCoord = new System.Windows.Forms.CheckBox();
            this.chkICoord = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.boxMaximum = new System.Windows.Forms.TextBox();
            this.boxMinimum = new System.Windows.Forms.TextBox();
            this.numKCfrom = new System.Windows.Forms.NumericUpDown();
            this.numJCfrom = new System.Windows.Forms.NumericUpDown();
            this.numICfrom = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKCto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJCto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numICto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKCfrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJCfrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numICfrom)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.glControl.Location = new System.Drawing.Point(159, 37);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(480, 479);
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
            this.openModelToolStripMenuItem,
            this.windowToolStripMenuItem});
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
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartToolStripMenuItem,
            this.dToolStripMenuItem,
            this.dToolStripMenuItem1});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.chartToolStripMenuItem.Text = "Chart";
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.dToolStripMenuItem.Text = "2D";
            // 
            // dToolStripMenuItem1
            // 
            this.dToolStripMenuItem1.Name = "dToolStripMenuItem1";
            this.dToolStripMenuItem1.Size = new System.Drawing.Size(101, 22);
            this.dToolStripMenuItem1.Text = "3D";
            // 
            // fileDialog
            // 
            this.fileDialog.Filter = "Eclipse file|*.SMSPEC";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(662, 37);
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
            this.boxRestartDate.Location = new System.Drawing.Point(661, 53);
            this.boxRestartDate.Name = "boxRestartDate";
            this.boxRestartDate.Size = new System.Drawing.Size(121, 21);
            this.boxRestartDate.TabIndex = 5;
            this.boxRestartDate.SelectedIndexChanged += new System.EventHandler(this.boxRestartDate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Properties";
            // 
            // treeProperties
            // 
            this.treeProperties.FullRowSelect = true;
            this.treeProperties.HideSelection = false;
            this.treeProperties.Location = new System.Drawing.Point(12, 63);
            this.treeProperties.Name = "treeProperties";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Static";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Dynamic";
            this.treeProperties.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.treeProperties.Size = new System.Drawing.Size(141, 348);
            this.treeProperties.TabIndex = 7;
            this.treeProperties.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeProperties_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(661, 97);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(250, 419);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numKCto);
            this.tabPage1.Controls.Add(this.numJCto);
            this.tabPage1.Controls.Add(this.numICto);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.chkMaximum);
            this.tabPage1.Controls.Add(this.chkMinimum);
            this.tabPage1.Controls.Add(this.chkKCoord);
            this.tabPage1.Controls.Add(this.chkJCoord);
            this.tabPage1.Controls.Add(this.chkICoord);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.boxMaximum);
            this.tabPage1.Controls.Add(this.boxMinimum);
            this.tabPage1.Controls.Add(this.numKCfrom);
            this.tabPage1.Controls.Add(this.numJCfrom);
            this.tabPage1.Controls.Add(this.numICfrom);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(242, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Filters";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numKCto
            // 
            this.numKCto.Location = new System.Drawing.Point(177, 90);
            this.numKCto.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numKCto.Name = "numKCto";
            this.numKCto.Size = new System.Drawing.Size(57, 21);
            this.numKCto.TabIndex = 6;
            this.numKCto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numJCto
            // 
            this.numJCto.Location = new System.Drawing.Point(177, 63);
            this.numJCto.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numJCto.Name = "numJCto";
            this.numJCto.Size = new System.Drawing.Size(57, 21);
            this.numJCto.TabIndex = 4;
            this.numJCto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numICto
            // 
            this.numICto.Location = new System.Drawing.Point(177, 36);
            this.numICto.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numICto.Name = "numICto";
            this.numICto.Size = new System.Drawing.Size(57, 21);
            this.numICto.TabIndex = 2;
            this.numICto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "From";
            // 
            // chkMaximum
            // 
            this.chkMaximum.AutoSize = true;
            this.chkMaximum.Location = new System.Drawing.Point(21, 166);
            this.chkMaximum.Name = "chkMaximum";
            this.chkMaximum.Size = new System.Drawing.Size(70, 17);
            this.chkMaximum.TabIndex = 15;
            this.chkMaximum.Text = "Maximum";
            this.chkMaximum.UseVisualStyleBackColor = true;
            // 
            // chkMinimum
            // 
            this.chkMinimum.AutoSize = true;
            this.chkMinimum.Location = new System.Drawing.Point(21, 138);
            this.chkMinimum.Name = "chkMinimum";
            this.chkMinimum.Size = new System.Drawing.Size(66, 17);
            this.chkMinimum.TabIndex = 14;
            this.chkMinimum.Text = "Minimum";
            this.chkMinimum.UseVisualStyleBackColor = true;
            // 
            // chkKCoord
            // 
            this.chkKCoord.AutoSize = true;
            this.chkKCoord.Location = new System.Drawing.Point(21, 91);
            this.chkKCoord.Name = "chkKCoord";
            this.chkKCoord.Size = new System.Drawing.Size(63, 17);
            this.chkKCoord.TabIndex = 13;
            this.chkKCoord.Text = "K-coord";
            this.chkKCoord.UseVisualStyleBackColor = true;
            // 
            // chkJCoord
            // 
            this.chkJCoord.AutoSize = true;
            this.chkJCoord.Location = new System.Drawing.Point(21, 64);
            this.chkJCoord.Name = "chkJCoord";
            this.chkJCoord.Size = new System.Drawing.Size(62, 17);
            this.chkJCoord.TabIndex = 12;
            this.chkJCoord.Text = "J-coord";
            this.chkJCoord.UseVisualStyleBackColor = true;
            // 
            // chkICoord
            // 
            this.chkICoord.AutoSize = true;
            this.chkICoord.Location = new System.Drawing.Point(21, 37);
            this.chkICoord.Name = "chkICoord";
            this.chkICoord.Size = new System.Drawing.Size(61, 17);
            this.chkICoord.TabIndex = 11;
            this.chkICoord.Text = "I-coord";
            this.chkICoord.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // boxMaximum
            // 
            this.boxMaximum.Location = new System.Drawing.Point(143, 164);
            this.boxMaximum.Name = "boxMaximum";
            this.boxMaximum.Size = new System.Drawing.Size(91, 21);
            this.boxMaximum.TabIndex = 8;
            // 
            // boxMinimum
            // 
            this.boxMinimum.Location = new System.Drawing.Point(143, 136);
            this.boxMinimum.Name = "boxMinimum";
            this.boxMinimum.Size = new System.Drawing.Size(91, 21);
            this.boxMinimum.TabIndex = 7;
            // 
            // numKCfrom
            // 
            this.numKCfrom.Location = new System.Drawing.Point(104, 90);
            this.numKCfrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numKCfrom.Name = "numKCfrom";
            this.numKCfrom.Size = new System.Drawing.Size(57, 21);
            this.numKCfrom.TabIndex = 5;
            this.numKCfrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numJCfrom
            // 
            this.numJCfrom.Location = new System.Drawing.Point(104, 63);
            this.numJCfrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numJCfrom.Name = "numJCfrom";
            this.numJCfrom.Size = new System.Drawing.Size(57, 21);
            this.numJCfrom.TabIndex = 3;
            this.numJCfrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numICfrom
            // 
            this.numICfrom.Location = new System.Drawing.Point(104, 36);
            this.numICfrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numICfrom.Name = "numICfrom";
            this.numICfrom.Size = new System.Drawing.Size(57, 21);
            this.numICfrom.TabIndex = 1;
            this.numICfrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            ((System.ComponentModel.ISupportInitialize)(this.numKCto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJCto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numICto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKCfrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJCfrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numICfrom)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numKCfrom;
        private System.Windows.Forms.NumericUpDown numJCfrom;
        private System.Windows.Forms.NumericUpDown numICfrom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox boxMaximum;
        private System.Windows.Forms.TextBox boxMinimum;
        private System.Windows.Forms.CheckBox chkMaximum;
        private System.Windows.Forms.CheckBox chkMinimum;
        private System.Windows.Forms.CheckBox chkKCoord;
        private System.Windows.Forms.CheckBox chkJCoord;
        private System.Windows.Forms.CheckBox chkICoord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numKCto;
        private System.Windows.Forms.NumericUpDown numJCto;
        private System.Windows.Forms.NumericUpDown numICto;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem1;
    }
}
