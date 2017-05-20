using System;
using System.Collections;
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
    class Arme : Item
    {
        private int ptsDegatMini;
        private int ptsDegatMaxi;

        public int GetPtsDegatMini
        {
            get { return ptsDegatMini; }
        }
        public int GetPtsDegatMaxi
        {
            get { return ptsDegatMaxi; }
        }

        public Arme(string pNom, string pDetails, char pTouche, bool pEquiped, int pNivRarete, int pCoutUtilisation, Bitmap pImage, Bitmap pImageVersGauche, Bitmap pImageVersDroite, int degatMini, int degatMaxi) : base(pNom, pDetails, pTouche, pEquiped, pNivRarete, pCoutUtilisation, pImage, pImageVersGauche, pImageVersDroite)
        {
            ptsDegatMini = degatMini;
            ptsDegatMaxi = degatMaxi;
        }
    }
}
