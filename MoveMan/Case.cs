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
    abstract class Case
    {
        /// <summary>
        /// Vrai si le block peut être traversé, faux sinon
        /// </summary>
        private bool traversable;
        /// <summary>
        /// Indique le coups de déplacement de la case Actuelle
        /// </summary>
        private int coupDeplacement;

        /// <summary>
        ///  Indique si la case à déjà été visité
        /// </summary>
        private bool visite;

        /// <summary>
        /// L'image de la case
        /// </summary>
        private PictureBox unePictureBox = new PictureBox();

        /// <summary>
        /// Un Item posé dans, sous, ou sur la case
        /// </summary>
        private Item unItem;


        // ACCESSEURS dans l'ordre d'apparition des propriétés



       public int GetCoupsDeplacement
        {
            get { return coupDeplacement; }
        }

        public bool GetSetVisite
        {
            get
            {
                return visite;
            }
            set
            {
                visite = value;
            }
        }

        public PictureBox GetUnePictureBox
        {
            get { return unePictureBox; }
        }

        public Item GetUnItem
        {
            get
            {
                return unItem;
            }
        }

        /// <summary>
        /// Constructeur de Case
        /// </summary>
        /// <param name="pTraversable">True si la case est traversable</param>
        /// <param name="pCpDeplacement">Le nombre de points de mouvement à dépenssé pour aller sur cette case</param>
        /// <param name="pBitmap">L'image représentant la case</param>
        public Case(bool pTraversable, int pCpDeplacement, Bitmap pBitmap)
        {
            traversable = pTraversable;
            coupDeplacement = pCpDeplacement;
            unePictureBox.Image = pBitmap;
        }

        /// <summary>
        /// Ce constructeur surchargé permet de donner un argument supplémentaire : pVisits
        /// </summary>
        /// <param name="pTraversable"></param>
        /// <param name="pCpDeplacement"></param>
        /// <param name="pBitmap"></param>
        /// <param name="pVisits">Si le joueur à déjà visité la case elle est égale à false</param>
        public Case(bool pTraversable, int pCpDeplacement, Bitmap pBitmap, bool pVisits)
        {
            traversable = pTraversable;
            coupDeplacement = pCpDeplacement;
            unePictureBox.Image = pBitmap;
            visite = pVisits;
        }

        public Case(bool pTraversable, int pCpDeplacement, Bitmap pBitmap, bool pVisits, Item pUnItem)
        {
            traversable = pTraversable;
            coupDeplacement = pCpDeplacement;
            unePictureBox.Image = pBitmap;
            visite = pVisits;
            unItem = pUnItem;
        }

        public Case(bool pTraversable, int pCpDeplacement, PictureBox pBitmap, Item pUnItem)
        {
            traversable = pTraversable;
            coupDeplacement = pCpDeplacement;
            unePictureBox = pBitmap;
            unItem = pUnItem;
        }


        /// <summary>
        /// Genere un coffre
        /// </summary>
        /// <param name="Dimenssion">La dimmenssion de la case souhaité (1 pour une case de 1X1, 2 pour une case de 2X2...)</param>
        /// <param name="positionVerticale">La coordonnées verticale de la case sur le plateau</param>/param>
        /// <param name="positionHorrizontale">La coordonnées horrizontale de la case sur le plateau</param>
        public virtual void Generer(int Dimenssion, int positionVerticale, int positionHorrizontale)
        {
            GetUnePictureBox.Width = 80 * Dimenssion;
            GetUnePictureBox.Height = 70 * Dimenssion;
            GetUnePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            int x = 81 * positionHorrizontale;
            int y = 71 * positionVerticale;
            GetUnePictureBox.Location = new Point(x, y);
        }
    }
}
