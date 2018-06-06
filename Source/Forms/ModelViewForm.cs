using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MWI
{
    public partial class ModelViewForm : DockContent
    {
        public ModelViewForm()
        {
            InitializeComponent();
            
        }

        private void ModelViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Program.mainform.modelViewShow = false;
            Program.mainform.modelViewToolStripMenuItem.Checked = false;
        }
    }
}
