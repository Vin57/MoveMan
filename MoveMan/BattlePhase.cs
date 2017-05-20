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
    partial class BattlePhase : Form
    {

        // Le joueur peut attaquer car il à assez de points d'action
        bool attaqueValid = false;
        Random leHasard = new Random();

        Personnage persoAttaquant;
        Personnage persoDefendant;

        int pointsAttaqueAttaquant;
        int pointsDefenseDefenseur;

        char moveDirection;

        /// <summary>
        /// Une Phase de battaille
        /// </summary>
        /// <param name="attaquant">Le personnage qui attaque</param>
        /// <param name="defenseur">Le personnage qui défend</param>
        public BattlePhase(Personnage attaquant, char pMoveDirection, Personnage defenseur)
        {
            InitializeComponent();

            moveDirection = pMoveDirection;

            persoAttaquant = attaquant;
            persoDefendant = defenseur;

            // L'attaquant :
            pictureBox1.Image = attaquant.GetSetItemPorte.GetImageVersDroite;
            PVattaquant.Text = "PV : " + attaquant.GetPV;
            PAattaquant.Text = "PA : " + attaquant.GetPtsAction;

            // Le defenseur :
            pictureBox2.Image = defenseur.GetImagePerso.Image;
            PVdefenseur.Text = "PV : " + defenseur.GetPV;
            PAdefenseur.Text = "PA : " + defenseur.GetPtsAction;
        }
        /// <summary>
        /// Va Fournir un nombre entre nbMini et nbMaxi et l'assigner au Personnage lePerso comme étant ses ptsAttaques
        /// </summary>
        /// <param name="lePerso">le perssonnage dont on lance les dés</param>
        /// <param name="nbMini">le nombre mini de points d'attaque de l'arme équipé</param>
        /// <param name="nbMaxi">le nombre maxi de points d'attaque de l'arme équipé</param>
        public int DessineUnDeAttaque(Personnage lePerso)
        {
            //// Au cas ou le joueur n'à pas équipé d'arme, on déclare une arme spéciale qui sont les mains nue du joueur
            //Arme armeUtilise = new Arme("Poins", "Vous attaquez à mains nue !", 'a', false, 1, 1, MoveMan.Properties.Resources.stickman, MoveMan.Properties.Resources.stickman, MoveMan.Properties.Resources.stickman, 100, 200);
            //foreach(Arme uneArme in lePerso.GetLesArmes)
            //{
            //    if(uneArme.GetSetEquiped)
            //    {
            //        // On à trouvé une arme équipé ! On remplace les Poins par l'arme équipée
            //        armeUtilise = uneArme;
            //    }
            //}
            if (lePerso.GetPtsAction >= lePerso.GetSetItemPorte.GetCoupPtsAction && lePerso.GetSetItemPorte is Arme)
            {
                int ptsAttaque = leHasard.Next(((Arme)lePerso.GetSetItemPorte).GetPtsDegatMini, ((Arme)lePerso.GetSetItemPorte).GetPtsDegatMaxi);
                PtsAttaqueAttaquant.Text = "Points d'attaque : " + Convert.ToString(ptsAttaque);
                lePerso.GetPtsAction -= lePerso.GetSetItemPorte.GetCoupPtsAction;
                attaqueValid = true;
                return ptsAttaque;
            }
            else
            {
                attaqueValid = false;
                return 0;
            }
        }

        public int DessineUnDeDefenseur(Personnage lePerso)
        {
            // Au cas ou le joueur n'à pas équipé d'arme, on déclare une arme spéciale qui sont les mains nue du joueur
            Arme armeUtilise = new Arme("Poins", "Vous attaquez à mains nue !", 'a', false, 1, 1, MoveMan.Properties.Resources.stickman, MoveMan.Properties.Resources.stickman, MoveMan.Properties.Resources.stickman, 100, 200);
            foreach (Arme uneArme in lePerso.GetLesArmes)
            {
                if (uneArme.GetSetEquiped)
                {
                    // On à trouvé une arme équipé ! On remplace les Poins par l'arme équipée
                    armeUtilise = uneArme;
                }
            }
            // On vérifie que le joueur à suffisament de PA pour attaquer

            int ptsDefense = leHasard.Next(armeUtilise.GetPtsDegatMini, armeUtilise.GetPtsDegatMaxi);
            PtsDefenseDefenseur.Text = "Points defense : " + Convert.ToString(ptsDefense);
            return ptsDefense;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pointsAttaqueAttaquant = DessineUnDeAttaque(persoAttaquant);
            if (attaqueValid)
            {
                pictureBox3.Visible = true;
                label2.Visible = true;
                pointsDefenseDefenseur = DessineUnDeDefenseur(persoDefendant);
                // Si le joueur inflige des points de dégâts
                if (pointsAttaqueAttaquant > pointsDefenseDefenseur)
                {
                    int pointDegat = pointsAttaqueAttaquant - pointsDefenseDefenseur;
                    
                    pictureBox3.Image = MoveMan.Properties.Resources.taches;
                    label2.Text = pointDegat + " Dégâts !";
                    label2.BringToFront();
                    persoDefendant.GetPV -= pointDegat;

                    // L'attaquant
                    PVattaquant.Text = "PV : " + persoAttaquant.GetPV;
                    PAattaquant.Text = "PA : " + persoAttaquant.GetPtsAction;

                    // Le defenseur
                    PVdefenseur.Text = "PV : " + persoDefendant.GetPV;
                    PAdefenseur.Text = "PA : " + persoDefendant.GetPtsAction;
                }
                // Sinon
                else
                {
                    pictureBox3.Image = MoveMan.Properties.Resources.Bouclier_du_Héros;
                    label2.Text = "Aucun dégâts";
                    label2.BringToFront();
                    // L'attaquant
                    PVattaquant.Text = "PV : " + persoAttaquant.GetPV;
                    PAattaquant.Text = "PA : " + persoAttaquant.GetPtsAction;

                    // Le defenseur
                    PVdefenseur.Text = "PV : " + persoDefendant.GetPV;
                    PAdefenseur.Text = "PA : " + persoDefendant.GetPtsAction;
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez plus assez de points d'action pour utiliser cette arme !\n fuillez et revenez avec une arme plus faible !");
                // L'attaquant
                PVattaquant.Text = "PV : " + persoAttaquant.GetPV;
                PAattaquant.Text = "PA : " + persoAttaquant.GetPtsAction;

                // Le defenseur
                PVdefenseur.Text = "PV : " + persoDefendant.GetPV;
                PAdefenseur.Text = "PA : " + persoDefendant.GetPtsAction;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (moveDirection == '6')
            {
                persoAttaquant.GetImagePerso.Image = persoAttaquant.GetSetItemPorte.GetImageVersGauche;
            }
            else
            {
                persoAttaquant.GetImagePerso.Image = persoAttaquant.GetSetItemPorte.GetImageVersDroite;
            }
            this.Close();
        }
    }
}
