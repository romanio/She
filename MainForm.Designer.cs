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
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.glControl.Location = new System.Drawing.Point(174, 37);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(483, 374);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 426);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(806, 22);
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
            this.menuStrip1.Size = new System.Drawing.Size(806, 24);
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
            this.label1.Location = new System.Drawing.Point(663, 37);
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
            this.boxRestartDate.Location = new System.Drawing.Point(666, 63);
            this.boxRestartDate.Name = "boxRestartDate";
            this.boxRestartDate.Size = new System.Drawing.Size(121, 21);
            this.boxRestartDate.TabIndex = 5;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 448);
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
    }
}
