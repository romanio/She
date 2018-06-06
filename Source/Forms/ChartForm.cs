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
    public partial class ChartForm : DockContent
    {
        public int id;
        public bool userClosing = false;

        public ChartForm()
        {
            InitializeComponent();
            this.DockAreas = DockAreas.Float | DockAreas.Document;
        }

        private void ChartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (userClosing == true)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                    Program.mainform.windowsList.SetCheckedState(id, false, Program.mainform.form2Dstring);
                    Hide();
                }
            }
        }
    }
}
