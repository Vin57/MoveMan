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
    partial class JoueurLanceDe : Form
    {
        #region Définition des variables global
        List<Personnage> lesPersonnages = new List<Personnage>();

        Random leHasard = new Random();

        List<Item> lesArmes = new List<Item>();
        Personnage leJoueur;
        Personnage deathWings;

        Point hautGauche = new Point(0, 0);
        Point basDroit = new Point(450, 320);

        Label unLabel = new Label();
        PictureBox unePictureBox = new PictureBox();

        bool viewItem = false; // True quand le joueur est entrain de regarder des items ! (il ne peut pas se déplacer en même temps)

        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();// Affichage d'images

        List<List<Case>> lesBlocks = new List<List<Case>>();
        List<Case> lesBlocksUn = new List<Case>();
        List<Case> lesBlocksDeux = new List<Case>();
        List<Case> lesBlocksTrois = new List<Case>();
        List<Case> lesBlocksQuatre = new List<Case>();
        List<Case> lesBlocksCinq = new List<Case>();
        List<Case> lesBlocksSix = new List<Case>();
        #endregion
        public JoueurLanceDe()
        {
            InitializeComponent();

            lesBlocks.Add(lesBlocksUn);
            lesBlocks.Add(lesBlocksDeux);
            lesBlocks.Add(lesBlocksTrois);
            lesBlocks.Add(lesBlocksQuatre);
            lesBlocks.Add(lesBlocksCinq);
            lesBlocks.Add(lesBlocksSix);

            for (int i = 0; i < 6; i++)
            {
                for (int a = 0; a < 7; a++)
                {
                    if (SpecialCase(i, a))
                    {
                    }
                    else
                    {
                        Herbe unBlockHerbe = new Herbe(true, 1, MoveMan.Properties.Resources.Herbe_Foret);
                        unBlockHerbe.Generer(1, i, a);
                        Controls.Add(unBlockHerbe.GetUnePictureBox);
                        lesBlocks[i].Add(unBlockHerbe);// On ajoute à la ligne i
                    }
                }
            }
            // Les personnages

            leJoueur = new Personnage("Joueur", lesArmes, 50, 1, 0, 10000, 3, 6, MoveMan.Properties.Resources.stickman, lesBlocks[1][0]);
            leJoueur.Generer(80, 70);
            Controls.Add(leJoueur.GetImagePerso);
            leJoueur.GetImagePerso.BringToFront();

            List<Item> armesChevalier = new List<Item>();
            Personnage chevalier1 = new Personnage("Chevalier", armesChevalier, 2, 3, 4, 100, 1, 3, MoveMan.Properties.Resources.Adversaire_Chevalier1, lesBlocks[3][4]);
            chevalier1.Generer(80, 70);
            Controls.Add(chevalier1.GetImagePerso);
            chevalier1.GetImagePerso.BringToFront();

            lesPersonnages.Add(leJoueur);
            lesPersonnages.Add(chevalier1);
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (viewItem == false)// Si le joueur est entrain de regarder un item il ne peut se déplacer
            {
                char touche = e.KeyChar;
                TryTouch(leJoueur, touche);
                label3.Text = "X (Horizontal) : " + Convert.ToString(leJoueur.GetSetLocalisationPersonnageX) + " - Case X : " + leJoueur.GetSetCaseHoriz;
                label4.Text = "Y (Verticale) : " + Convert.ToString(leJoueur.GetSetLocalisationPersonnageY) + " - Case Y : " + leJoueur.GetSetCaseVert;
                leJoueur.GetImagePerso.Location = leJoueur.GetSetLocalisationPersonnage;
                if (lesBlocks[leJoueur.GetSetCaseHoriz][leJoueur.GetSetCaseVert] is Coffre && lesBlocks[leJoueur.GetSetCaseHoriz][leJoueur.GetSetCaseVert].GetSetVisite == false)
                {
                    // L'image du coffre fermé devient un coffre ouvert
                    lesBlocks[leJoueur.GetSetCaseHoriz][leJoueur.GetSetCaseVert].GetUnePictureBox.Image = MoveMan.Properties.Resources.OpenedBox;
                    // On donne le nom Item à L'ItemBox pour le repérer parmis les Images dans la ControlsCollection du Form1
                    ItemBox.Name = "Item";

                    // Le details et l'image de l'item deviennent visible
                    label1.Visible = true;
                    ItemBox.Visible = true;
                    // On donne l'image de l'item sur lequel se trouve le joueur à l'itemBox, et le détails de l'item sur lequel se trouve le joueurau label1
                    ItemBox.Image = lesBlocks[leJoueur.GetSetCaseHoriz][leJoueur.GetSetCaseVert].GetUnItem.GetuneImage;
                    label1.Text = lesBlocks[leJoueur.GetSetCaseHoriz][leJoueur.GetSetCaseVert].GetUnItem.GetDetails;
                    ItemBox.BringToFront();
                    label1.BringToFront();
                    // On ajoute l'item dans l'inventaire du joueur
                    leJoueur.GetLesArmes.Add(((Coffre)lesBlocks[leJoueur.GetSetCaseHoriz][leJoueur.GetSetCaseVert]).GetUnItem);

                    // Le joueur regarde un Item...
                    viewItem = true;

                    // ...Il doit le regarder pendant au moins X secondes
                    myTimer.Tick += eventTick;
                    myTimer.Interval = 2000;
                    myTimer.Start();
                    viewItem = true;
                }
            }
        }

        private void eventTick(object sender, EventArgs args)
        {
            myTimer.Stop();
            foreach (Object unObjet in Controls)
            {
                if (unObjet is PictureBox)
                {
                    if (((PictureBox)unObjet).Name == "Item")
                    {
                        // On permet au joueur d'arréter de regarder l'image
                        ItemBox.Cursor = Cursors.Hand;

                        // On lie l'événement pictureBoxItems_Click au clique sur ItemBox (la procédure s'éxécute au clique)
                        ItemBox.Click += pictureBoxItems_Click;
                    }
                }
            }
        }

        public void TryTouch(Personnage lePerso, char touchePush)
        {
            // Le joueur se déplace //
            if ((touchePush == '8' || touchePush == '6' || touchePush == '4' || touchePush == '2') && lePerso.GetPtsDeplacementsPourLeTour > 0)
            {
                if (touchePush == '8')
                {
                    if (lePerso.GetSetLocalisationPersonnageY > hautGauche.Y)
                    {
                        lePerso.GetSetCaseHoriz -= 1;
                        lePerso.GetSetLocalisationPersonnageY -= 70;
                    }
                }
                if (touchePush == '4')
                {
                    if (lePerso.GetSetLocalisationPersonnageX > hautGauche.X + 9)// Le joueur commence en position 7
                    {
                        lePerso.GetSetCaseVert -= 1;
                        lePerso.GetSetLocalisationPersonnageX -= 80;
                    }
                    lePerso.GetImagePerso.Image = lePerso.GetSetItemPorte.GetImageVersGauche;

                }
                if (touchePush == '6')
                {
                    if (lePerso.GetSetLocalisationPersonnageX < basDroit.X)
                    {
                        lePerso.GetSetCaseVert += 1;
                        lePerso.GetSetLocalisationPersonnageX += 80;
                    }
                    lePerso.GetImagePerso.Image = lePerso.GetSetItemPorte.GetImageVersDroite;
                }
                if (touchePush == '2')
                {
                    if (lePerso.GetSetLocalisationPersonnageY < basDroit.Y)
                    {
                        lePerso.GetSetCaseHoriz += 1;
                        lePerso.GetSetLocalisationPersonnageY += 70;
                    }
                }

                IsEventCase(leJoueur);

                lePerso.GetPtsDeplacementsPourLeTour -= lesBlocks[lePerso.GetSetCaseHoriz][lePerso.GetSetCaseVert].GetCoupsDeplacement;
                label2.Text = "Move Points : " + lePerso.GetPtsDeplacementsPourLeTour;

                // Le joueur est tombé sur un monstre et entame le combat //
                foreach (Personnage unDefenseur in lesPersonnages)
                {
                    if ((unDefenseur != lePerso) && (lePerso.GetSetCaseHoriz == unDefenseur.GetSetCaseHoriz && lePerso.GetSetCaseVert == unDefenseur.GetSetCaseVert))
                    {
                        BattlePhase battle = new BattlePhase(lePerso, touchePush, unDefenseur);
                        battle.ShowDialog();
                        if (unDefenseur.GetPV > 0)// Si le defenseur est toujours vivant on ne peut pas aller sur sa case
                        {

                            if (touchePush == '8')
                            {
                                if (lePerso.GetSetLocalisationPersonnageY > hautGauche.Y)
                                {
                                    lePerso.GetSetCaseHoriz += 1;
                                    lePerso.GetSetLocalisationPersonnageY += 70;
                                }
                            }
                            if (touchePush == '4')
                            {
                                if (lePerso.GetSetLocalisationPersonnageX > hautGauche.X + 9)// Le joueur commence en position 7
                                {
                                    lePerso.GetSetCaseVert += 1;
                                    lePerso.GetSetLocalisationPersonnageX += 80;
                                }
                                foreach (Item unItemPortee in lePerso.GetLesArmes)
                                {
                                    if (unItemPortee.GetSetEquiped)
                                    {
                                        lePerso.GetImagePerso.Image = unItemPortee.GetImageVersDroite;
                                    }
                                }
                            }
                            if (touchePush == '6')
                            {
                                if (lePerso.GetSetLocalisationPersonnageX < basDroit.X)
                                {
                                    lePerso.GetSetCaseVert -= 1;
                                    lePerso.GetSetLocalisationPersonnageX -= 80;
                                }
                                foreach (Item unItemPortee in lePerso.GetLesArmes)
                                {
                                    if (unItemPortee.GetSetEquiped)
                                    {
                                        lePerso.GetImagePerso.Image = unItemPortee.GetImageVersGauche;
                                    }
                                }
                            }
                            if (touchePush == '2')
                            {
                                if (lePerso.GetSetLocalisationPersonnageY < basDroit.Y)
                                {
                                    lePerso.GetSetCaseHoriz -= 1;
                                    lePerso.GetSetLocalisationPersonnageY -= 70;
                                }
                            }
                        }
                        else
                        {
                            unDefenseur.GetSetCaseHoriz = -1;
                            unDefenseur.GetSetCaseVert = -1;
                            unDefenseur.GetImagePerso.Image = MoveMan.Properties.Resources.pierre_tombale;
                        }
                    }
                }

                lePerso.GetImagePerso.BringToFront();
                if (lePerso.GetPtsDeplacementsPourLeTour == 0)
                {
                    // Début tour ordi
                    leJoueur.Awake = false;
                    JouerOrdi();
                    button1.Visible = true;
                    button2.Visible = false;
                }
            }
            // Utilisation d'items / d'Armes... //
            else
            {
                foreach (Item unItem in lePerso.GetLesArmes)
                {
                    if (touchePush == unItem.GetTouche)
                    {
                        if (unItem.GetSetEquiped == false)
                        {
                            lePerso.GetImagePerso.Image = unItem.GetImageVersDroite;
                            unItem.GetSetEquiped = true;
                            lePerso.GetSetItemPorte = unItem;
                        }
                        else
                        {
                            lePerso.GetImagePerso.Image = MoveMan.Properties.Resources.stickman;
                            unItem.GetSetEquiped = false;
                        }
                    }
                    else
                    {
                        // Tous les autres items sont rangé dans l'inventaire par précautions
                        unItem.GetSetEquiped = false;
                    }
                }
            }
        }

        /// <summary>
        /// "Événement" lié au clique sur ItemBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxItems_Click(object sender, EventArgs e)
        {
            ItemBox.Visible = false;
            label1.Visible = false;
            lesBlocks[leJoueur.GetSetCaseHoriz][leJoueur.GetSetCaseVert].GetSetVisite = true;// le coffre sur lequel est le joueur à été ouvert
            viewItem = false;
        }


        /// <summary>
        /// Créé une case spécial (non majoritaire)
        /// </summary>
        /// <param name="horizontale">Coordonnées Y</param>
        /// <param name="verticale">Coordonnées X</param>
        /// <returns>retourne vrai si la case à été créé en une case spécial</returns>
        public bool SpecialCase(int horizontale, int verticale)
        {
            if (horizontale == 2 && verticale == 4)
            {
                Bitmap Image = MoveMan.Properties.Resources.ClosedBox;
                Arme Excalibur = new Arme("Excalibur", "Vous avez trouvé excalibur, l'épée légendaire !\n On dirait qu'il manque son fourreaux...\n (X pour équiper)", 'x', false, 10, 8, MoveMan.Properties.Resources.Excalibur, MoveMan.Properties.Resources.stickman2, MoveMan.Properties.Resources.stickman1, 1000000, 2000000);
                Coffre unCoffre = new Coffre(true, 1, Image, false, Excalibur);
                unCoffre.Generer(1, horizontale, verticale);
                Controls.Add(unCoffre.GetUnePictureBox);
                lesBlocks[horizontale].Add(unCoffre);// On ajoute à la ligne i
                return true;
            }
            if (horizontale == 1 && verticale == 2)
            {
                // On créé un nouveau coffre
                Bitmap uneImageDeCoffre = MoveMan.Properties.Resources.ClosedBox;
                Arme Dague = new Arme("Dague", "Une Petite Dague légére et peu puissante\n (D pour équiper)", 'd', false, 2, 2, MoveMan.Properties.Resources.Dague, MoveMan.Properties.Resources.stickmanDagueGauche, MoveMan.Properties.Resources.stickmanDagueDroite, 1000, 1100);
                Coffre unCoffre = new Coffre(true, 1, uneImageDeCoffre, false, Dague);

                // On génére notre coffre
                unCoffre.Generer(1, horizontale, verticale);
                Controls.Add(unCoffre.GetUnePictureBox);
                lesBlocks[horizontale].Add(unCoffre);// On ajoute à la ligne i
                return true;
            }
            return false;
        }

        /// <summary>
        /// Va Fournir un nombre entre nbMini et nbMaxi et l'assigner au Personnage lePerso comme étant ses ptsDeplacementsPourLeTour
        /// </summary>
        /// <param name="lePerso"></param>
        /// <param name="nbMini"></param>
        /// <param name="nbMaxi"></param>
        public void DessineUnDe(Personnage lePerso, int nbMini, int nbMaxi)
        {
            int valeurDe = leHasard.Next(nbMini, nbMaxi);
            label2.Text = "Move Points : " + Convert.ToString(valeurDe);
            lePerso.GetPtsDeplacementsPourLeTour = valeurDe;
            // C'est le début du tour du Personnage, on lui rend tous ces points Action
            lePerso.GetPtsAction = lePerso.savePtsAction;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lancer de dés du joueur
            DessineUnDe(leJoueur, leJoueur.GetptsDeplacementMini, leJoueur.GetptsDeplacementMaxi);
            button1.Visible = false;
            button2.Visible = true;
            this.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Fin tour joueur (surender)
            button1.Visible = true;
            button2.Visible = false;
            this.Focus();
            // Début tour ordi
            leJoueur.Awake = false;
            JouerOrdi();
        }

        private void JouerOrdi()
        {
            foreach (Personnage unPersonnage in lesPersonnages)
            {
                if (unPersonnage.Awake)
                {
                    DessineUnDe(unPersonnage, unPersonnage.GetptsDeplacementMini, unPersonnage.GetptsDeplacementMaxi);
                }
            }
        }

        private void IsEventCase(Personnage lePerso)
        {
            if (lePerso.GetSetCaseVert == 4 && lePerso.GetSetCaseHoriz == 2 && lesBlocks[2][4].GetSetVisite == false)
            {
                List<Item> armesAileDeMort = new List<Item>();
                Arme FlammeSombre = new Arme("Flame Sombre", "Des flammes dépourvues de toutes lumiéres et \nplongeant ceux qu'elles touche dans les ténébres", 'f', true, 11, 7, MoveMan.Properties.Resources.flamme_Sombre, MoveMan.Properties.Resources.flamme_Sombre, MoveMan.Properties.Resources.flamme_Sombre, 1000000, 1500000);
                armesAileDeMort.Add(FlammeSombre);
                deathWings = new Personnage("Aile de mort", armesAileDeMort, 42, 2, 5, 999999, 10, 20, MoveMan.Properties.Resources.deathwing, lesBlocks[2][5]);
                deathWings.Generer(80, 70);
                Controls.Add(deathWings.GetImagePerso);
                deathWings.GetImagePerso.BringToFront();

                lesPersonnages.Add(deathWings);
            }
        }
    }
}