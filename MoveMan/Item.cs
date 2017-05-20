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
    abstract class Item
    {
        private string nom;
        private string details;
        private char touche;
        private bool equiped;
        private int nivRarete;
        private int coupPointsAction;
        private Bitmap uneImage;
        private Bitmap imageSurPersoGauche;
        private Bitmap imageSurPersoDroite;


        public string GetDetails
        {
            get { return details; }
        }

        public char GetTouche
        {
            get
            {
                return touche;
            }
        }

        public bool GetSetEquiped
        {
            get
            {
                return equiped;
            }
            set
            {
                equiped = value;
            }
        }

        public int GetNivRarete
        {
            get { return nivRarete; }
        }

        public int GetCoupPtsAction
        {
            get { return coupPointsAction; }
        }

        public Bitmap GetuneImage
        {
            get
            {
                return uneImage;
            }
            set
            {
                uneImage = value;
            }
        }

        public Bitmap GetImageVersGauche
        {
            get { return imageSurPersoGauche; }
        }

        public Bitmap GetImageVersDroite
        {
            get { return imageSurPersoDroite; }
        }

        /// <summary>
        /// Un Items rammassable ou non par le joueur
        /// </summary>
        /// <param name="pNom">Le nom de l'item</param>
        /// <param name="pDetails">Les détails de l'item (histoire, anecdote...)</param>
        ///  <param name="pNivRarete">Le niveau de rareté de l'arme (de 1 à 10)</param>
        /// <param name="pTouche">La touche à pressé pour utiliser l'item</param>
        /// <param name="pEquiped">Vrai si l'item est équipé (dans les mains du joueur)</param>
        /// <param name="pPersoVersGauche">L'image du personnage quand il va vers la gauche</param>
        /// <param name="pPersoVersDroite">L'image du personnage quand il va vers la droite</param>
        public Item(string pNom, string pDetails, char pTouche, bool pEquiped, int pNivRarete, int pCoutUtilisation, Bitmap pImage, Bitmap pPersoVersGauche, Bitmap pPersoVersDroite)
        {
            nom = pNom;
            details = pDetails;
            touche = pTouche;
            equiped = pEquiped;
            nivRarete = pNivRarete;
            coupPointsAction = pCoutUtilisation;
            uneImage = pImage;
            imageSurPersoGauche = pPersoVersGauche;
            imageSurPersoDroite = pPersoVersDroite;
        }

        /// <summary>
        /// Retourne un nom pour le niveau de rareté
        /// </summary>
        /// <returns>Retourne la rareté</returns>
        public string NiveauRarete()
        {
            switch (nivRarete)
            {
                case 1:
                    return "Déchet";
                case 2:
                    return "Commun";
                case 3:
                    return "Intéressant";
                case 4:
                    return "Apprécié";
                case 5:
                    return "Recherché";
                case 6:
                    return "Rare";
                case 7:
                    return "Unique";
                case 8:
                    return "Légendaire";
                case 9:
                    return "Mythique";
                case 10:
                    return "Divin";
                default:
                    return "Inconnue";
            }
        }

        /// <summary>
        /// Retourne une PictureBox de l'image de l'item
        /// </summary>
        /// <param name="uneImage">L'image de l'item</param>
        /// <returns></returns>
        public PictureBox GenereImageItem(int largeur, int hauteur, int coordonneVerticale, int coordonneHorizontale)
        {
            // Création de l'image
            PictureBox unePictureBox = new PictureBox();
            unePictureBox.Image = uneImage;
            unePictureBox.Width = largeur;
            unePictureBox.Height = hauteur;
            Point unPoint = new Point(coordonneVerticale, coordonneHorizontale);
            unePictureBox.Location = unPoint;

            // Retourne une pictureBox
            return unePictureBox;
        }
    }
}
