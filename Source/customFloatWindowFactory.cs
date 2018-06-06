using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MWI
{
    class customFloatWindowFactory : DockPanelExtender.IFloatWindowFactory
    {
        public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane, Rectangle bounds)
        {
            return new customFloatWindow(dockPanel, pane, bounds);
        }
        public FloatWindow CreateFloatWindow(DockPanel dockPanel, DockPane pane)
        {
            return new customFloatWindow(dockPanel, pane);
        }
    }
}