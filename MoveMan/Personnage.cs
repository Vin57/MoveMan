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
    class Personnage
    {
        // ATTRIBUTS
        // Les stats total de points d'action (rendu à chaque début de tour)
        public int savePtsAction;

        private Item itemPortee = new Arme("Poins", "Vous attaquez à mains nue !", 'a', false, 1, 1, MoveMan.Properties.Resources.stickman, MoveMan.Properties.Resources.stickman, MoveMan.Properties.Resources.stickman, 100, 200);

        private string nom;
        private int ptsAction;

        // Indique si le personnage est éveillé et peu joué son tour
        private bool awake;
        

        // Permet de définir un interval pour les lancer de dés
        private int ptsDeplacementMini;
        private int ptsDeplacementMaxi;

        private int ptsDeplacementsPourLeTour;

        //// Inventaire des armes possédé par le joueur ////
        private List<Item> lesArmes = new List<Item>();

        //// Localisation du personnage sur les case ////
        private int caseVert;
        private int caseHoriz;

        //// Localisation de l'image représentant le personnage sur le plateau ////
        private Point localisationPersonnage = new Point();

        private int PV;

        //// Représentation du personnage
        private PictureBox imagePerso = new PictureBox();
        

        // ACCESSEUR les accesseurs en lecture et écriture peuvent être des statistiques du joueur pouvant évolué avec son niveau


        public Item GetSetItemPorte
        {
            get
            {
                return itemPortee;
            }
            set
            {
                itemPortee = value;
            }
        }

        public string GetNom
        {
            get
            {
                return nom;
            }
        }

        public int GetptsDeplacementMini
        {
            get
            {
                return ptsDeplacementMini;
            }
            set
            {
                ptsDeplacementMini = value;
            }
        }

        public int GetptsDeplacementMaxi
        {
            get
            {
                return ptsDeplacementMaxi;
            }
            set
            {
                ptsDeplacementMaxi = value;
            }
        }

        public int GetPtsAction
        {
            get
            {
                return ptsAction;
            }
            set
            {
                ptsAction = value;
            }
        }

        public int GetPtsDeplacementsPourLeTour
        {
            get
            {
                return ptsDeplacementsPourLeTour;
            }
            set
            {
                ptsDeplacementsPourLeTour = value;
            }
        }

        public List<Item> GetLesArmes
        {
            get { return lesArmes; }
        }

        public Point GetSetLocalisationPersonnage
        {
            get
            {
                return localisationPersonnage;
            }
        }

        public int GetSetLocalisationPersonnageX
        {
            get
            {
                return localisationPersonnage.X;
            }
            set
            {
                localisationPersonnage.X = value;
            }
        }

        public int GetSetLocalisationPersonnageY
        {
            get
            {
                return localisationPersonnage.Y;
            }
            set
            {
                localisationPersonnage.Y = value;
            }
        }

        public int GetSetCaseHoriz
        {
            get { return caseHoriz; }
            set { caseHoriz = value; }
        }

        public int GetSetCaseVert
        {
            get { return caseVert; }
            set { caseVert = value; }
        }

        public int GetPV
        {
            get { return PV; }
            set
            {
                PV = value;
            }
        }

        public PictureBox GetImagePerso
        {
            get { return imagePerso; }
        }

        public bool Awake
        {
            get
            {
                return awake;
            }

            set
            {
                awake = value;
            }
        }

        // CONSTRUCTEUR d'un personnage positionné par rapport à une case
        public Personnage(string Nom, List<Item> listeArmes, int pPointsAction, double pCaseHorizontale, double pCaseVerticale, int pPointsVie, int pPointsDeplacementMini, int pPointsDeplacementMaxi, Bitmap pImagePerso, Case pUneCase)
        {
            nom = Nom;
            lesArmes = listeArmes;
            ptsAction = pPointsAction;
            savePtsAction = pPointsAction;
            // Ici on à pas besoin de la précision d'un nombre à virgule
            caseVert = Convert.ToInt32(pCaseVerticale);
            caseHoriz = Convert.ToInt32(pCaseHorizontale);
            // Ici oui
            localisationPersonnage.X = pUneCase.GetUnePictureBox.Location.X + 6;
            localisationPersonnage.Y = pUneCase.GetUnePictureBox.Location.Y - 20;
            PV = pPointsVie;
            imagePerso.Image = pImagePerso;
            ptsDeplacementMini = pPointsDeplacementMini;
            ptsDeplacementMaxi = pPointsDeplacementMaxi;
            awake = true;
        }

        /// METHODES
        public void Generer(int DimenssionHauteur, int DimmenssionLargeur)
        {
            imagePerso.Height = DimenssionHauteur;
            imagePerso.Width = DimmenssionLargeur;
            imagePerso.SizeMode = PictureBoxSizeMode.StretchImage;
            int x = GetSetLocalisationPersonnageX;
            int y = GetSetLocalisationPersonnageY;
            imagePerso.Location = new Point(x, y);
        }
    }
}
