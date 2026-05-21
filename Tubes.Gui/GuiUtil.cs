using System;
using System.Collections.Generic;
using System.Text;

namespace Tubes.Gui
{
    public class GuiUtil
    {
        // The centering method
        public static void CenterChildPanel(Panel parent, Panel child)
        {
            int centerX = (parent.ClientSize.Width - child.Width) / 2;
            int centerY = (parent.ClientSize.Height - child.Height) / 2;

            child.Location = new Point(centerX, centerY);
        }
    }
}
