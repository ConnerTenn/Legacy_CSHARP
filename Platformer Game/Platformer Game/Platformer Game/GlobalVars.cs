using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platformer_Game
{
    class GlobalVars
    {
        public static List<Objects> ObjectList = new List<Objects>();
        public static Pen myPen = new Pen(Color.Black);
        public static Graphics graphics = null;
        public static Panel canvas = Application.OpenForms["Form1"].Controls["screen"] as Panel;
    }
}
