namespace MWI
{
    partial class WindowListForm
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
            this.components = new System.ComponentModel.Container();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form2DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form3DToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chartToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.from2DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form3DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(246, 523);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 52);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.form2DToolStripMenuItem,
            this.form3DToolStripMenuItem1,
            this.chartToolStripMenuItem1});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.newToolStripMenuItem.Text = "New";
            // 
            // form2DToolStripMenuItem
            // 
            this.form2DToolStripMenuItem.Name = "form2DToolStripMenuItem";
            this.form2DToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.form2DToolStripMenuItem.Text = "Form 2D";
            this.form2DToolStripMenuItem.Click += new System.EventHandler(this.form2DToolStripMenuItem_Click);
            // 
            // form3DToolStripMenuItem1
            // 
            this.form3DToolStripMenuItem1.Name = "form3DToolStripMenuItem1";
            this.form3DToolStripMenuItem1.Size = new System.Drawing.Size(141, 26);
            this.form3DToolStripMenuItem1.Text = "Form 3D";
            this.form3DToolStripMenuItem1.Click += new System.EventHandler(this.form3DToolStripMenuItem1_Click);
            // 
            // chartToolStripMenuItem1
            // 
            this.chartToolStripMenuItem1.Name = "chartToolStripMenuItem1";
            this.chartToolStripMenuItem1.Size = new System.Drawing.Size(141, 26);
            this.chartToolStripMenuItem1.Text = "Chart";
            this.chartToolStripMenuItem1.Click += new System.EventHandler(this.chartToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // from2DToolStripMenuItem
            // 
            this.from2DToolStripMenuItem.Name = "from2DToolStripMenuItem";
            this.from2DToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // deleteWindowToolStripMenuItem
            // 
            this.deleteWindowToolStripMenuItem.Name = "deleteWindowToolStripMenuItem";
            this.deleteWindowToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // form3DToolStripMenuItem
            // 
            this.form3DToolStripMenuItem.Name = "form3DToolStripMenuItem";
            this.form3DToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // WindowListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 523);
            this.Controls.Add(this.treeView1);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WindowListForm";
            this.Text = "Windows";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowListForm_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem from2DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form3DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form2DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form3DToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}