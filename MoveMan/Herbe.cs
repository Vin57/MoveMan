using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveMan
{
    class Herbe : Case
    {
        public Herbe(bool pTraversable, int pCpDeplacement, Bitmap uneImage) : base(pTraversable, pCpDeplacement, uneImage)
        {

        }
    }
}
