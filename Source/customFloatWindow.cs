using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Drawing;

namespace MWI
{
    class customFloatWindow : FloatWindow
    {
        public customFloatWindow(DockPanel dockPanel, DockPane pane) : base(dockPanel, pane)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            ShowInTaskbar = true;
            Owner = null;
        }
        public customFloatWindow(DockPanel dockPanel, DockPane pane, Rectangle bounds) : base(dockPanel, pane, bounds)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            ShowInTaskbar = true;
            Owner = null;
        }
    }
}

