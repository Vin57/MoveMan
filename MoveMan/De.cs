using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MoveMan
{
    class De
    {
        private int valeur;
        private PictureBox imageDe = new PictureBox();

        public int GetValeur
        {
            get { return valeur; }
        }

        public PictureBox GetImageDe
        {
            get { return imageDe; }
        }

        public De(int pValeur,PictureBox pImageDe)
        {
            valeur = pValeur;
            imageDe = pImageDe;
        }
    }
}
