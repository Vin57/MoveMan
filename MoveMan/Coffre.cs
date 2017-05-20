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
    class Coffre : Case
    {
        public Coffre(bool pTraversable, int pCpDeplacement, Bitmap uneImage, bool evenVisite, Item unItem) : base(pTraversable, pCpDeplacement, uneImage, evenVisite, unItem)
        {

        }

    }
}
