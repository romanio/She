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
    public partial class Form3D : DockContent
    {
        public int id;
        public bool userClosing = false;

        public Form3D()
        {
            InitializeComponent();
            this.DockAreas = DockAreas.Float | DockAreas.Document;
        }

        private void Form3D_FormClosing(object sender, FormClosingEventArgs e)
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
