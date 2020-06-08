using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssisesSportLorrain
{
    public partial class ASL : Form
    {
        public ASL()
        {
            InitializeComponent();
            tabControl.TabPages.Remove(hideShow1);
            tabControl.TabPages.Remove(hideShow2);
        }

        #region Onglet Accueil
        // Onglet ACCUEIL
        //====================================================================
        private void tabAccueil_Enter(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txbLogin.Text.Length == 0 || txbMdp.Text.Length == 0)
            {
                MessageBox.Show("Erreur : Saisis tous les champs !");
                return;
            }
            else
            {
                Utilisateur unNewUtilisateur;
                unNewUtilisateur = new Utilisateur(txbLogin.Text, txbMdp.Text);



                /*foreach (Utilisateur unUtilisateur in Utilisateur.listeUtilisateurs())
                {
                    if (unUtilisateur.ToString() == unNewUtilisateur.ToString())
                    {
                        txbLogin.Clear();
                        txbMdp.Clear();

                        tabControl.TabPages.Add(hideShow1);
                        tabControl.TabPages.Add(hideShow2);
                    }
                    
                    else
                    {
                        MessageBox.Show("Erreur : Login ou Mot de passe incorrect !");
                        return;
                    }
                    
                }*/


                if (Utilisateur.lUtilisateur().ToString() == unNewUtilisateur.ToString())
                {
                    txbLogin.Clear();
                    txbMdp.Clear();

                    tabControl.TabPages.Add(hideShow1);
                    tabControl.TabPages.Add(hideShow2);
                }
                else
                {
                    MessageBox.Show("Erreur : Login ou Mot de passe incorrect !");
                    return;
                }
            }
        }


        #endregion




        #region Onglet Atelier
        // Onglet ATELIER
        //====================================================================
        private void tabAteliers_Enter(object sender, EventArgs e)
        {
            //REMPLISSAGE DU DGV ATELIER
            remplirListeAtelier();

            //REMPLISSAGE COMBOBOX MODIFIER ATELIER
            remplirCbxModifierAtelier();

            //REMPLISSAGE COMBOBOX SUPPRIMER ATELIER
            remplirCbxSupprimerAtelier();

            //CACHER TOUS LES MESSAGES
            lblCreerAtelierOK.Hide();
            lblModifierAtelierOK.Hide();
            lblSupprimerAtelierOK.Hide();
            

        }





            //LES FONCTIONS ET PROCEDURES ONGLET : ATELIER

        //REMPLISSAGE DGV ATELIER
        private void remplirListeAtelier()
        {
            dgvAteliers.Rows.Clear();
            foreach (Atelier unAtelier in Atelier.listeAteliers())
            {
                dgvAteliers.Rows.Add(unAtelier.IdAtelier, unAtelier.LibelleAtelier, unAtelier.ParticipantAtelier);
            }
        }


        //REMPLISSAGE COMBOBOX MODIFIER ATELIER
        private void remplirCbxModifierAtelier()
        {
            cbxModifierAteliers.Items.Clear();
            foreach (Atelier unAtelier in Atelier.listeAteliers())
            {
                cbxModifierAteliers.Items.Add(unAtelier.IdAtelier);
            }
        }

        //REMPLISSAGE COMBOBOX SUPPRIMER ATELIER
        private void remplirCbxSupprimerAtelier()
        {
            cbxSupprimerAteliers.Items.Clear();
            foreach (Atelier unAtelier in Atelier.listeAteliers())
            {
                cbxSupprimerAteliers.Items.Add(unAtelier.IdAtelier);
            }
        }



        private void btnCreerAtelier_Click(object sender, EventArgs e)
        {
            if (txbCréerAtelier1.Text.Length == 0 || txbCréerAtelier2.Text.Length == 0 || txbCréerAtelier3.Text.Length == 0)
            {
                MessageBox.Show("Erreur : Saisis tous les champs !");
                return;
            }
            else
            {
                Atelier unNewAtelier;
                unNewAtelier = new Atelier(int.Parse(txbCréerAtelier1.Text), txbCréerAtelier2.Text, int.Parse(txbCréerAtelier3.Text));
                unNewAtelier.ajouterAtelier3();

      
                //Vider les tbx.text
                txbCréerAtelier1.Clear();
                txbCréerAtelier2.Clear();
                txbCréerAtelier3.Clear();


                //Afficher MSG VALIDER
                lblCreerAtelierOK.Show();
            }
        }


       

        private void btnModifierAtelier_Click(object sender, EventArgs e)
        {
            // on récupère l'index de la sélection dans la combobox
            int i = cbxModifierAteliers.SelectedIndex + 1;
            Atelier unAtelier;
            unAtelier = Atelier.listeAteliers().ElementAt(i);
            unAtelier.modifierAtelier(cbxModifierAteliers.SelectedIndex, txbModifierAtelier2.Text, int.Parse(txbModifierAtelier3.Text));



            /*
            txbModifierAtelier2.Text = unAtelier.libelleAtelier;
            txbModifierAtelier3.Text = unAtelier.nbParticipantsAtelier.ToString();
            */

            //Vider les textbox apres l'ajout
            txbModifierAtelier2.Clear();
            txbModifierAtelier3.Clear();

            lblModifierAtelierOK.Show();
        }




        private void btnSupprimerAtelier_Click(object sender, EventArgs e)
        {
            if (this.cbxSupprimerAteliers.SelectedIndex == -1)
            {
                MessageBox.Show("Erreur : Selectionne un Atelier !");
                return;
            }
            else
            {
                // on récupère l'index de la sélection dans la combobox
                int i = cbxSupprimerAteliers.SelectedIndex;

                Atelier unAtelier;
                unAtelier = Atelier.listeAteliers().ElementAt(i);
                unAtelier.supprimerAtelier();

                lblSupprimerAtelierOK.Show();

            }
        }



        //BOUTON TOUT ANNULER ATELIER
        private void btnAnnulerAtelier_Click(object sender, EventArgs e)
        {
            txbCréerAtelier1.Clear();
            txbCréerAtelier2.Clear();
            txbCréerAtelier3.Clear();
            txbModifierAtelier2.Clear();
            txbModifierAtelier3.Clear();
        }
        #endregion



        #region Onglet Thème
        // Onglet THEME
        //====================================================================
        private void tabThemes_Enter(object sender, EventArgs e)
        {
            //REMPLISSAGE DU DGV THEME
            remplirDgvTheme();

            //REMPLISSAGE COMBOBOX MODIFIER THEME
            remplirCbxModifierTheme();

            //REMPLISSAGE COMBOBOX SUPPRIMER THEME
            remplirCbxSupprimerTheme();

            //CACHER MESSAGES ERREURS
            lblCreerThemeOK.Hide();
            lblModifierThemeOK.Hide();
            lblSupprimerThemeOK.Hide();
        }





            //LES FONCTIONS ET PROCEDURES ONGLET : THEME
        //REMPLISSAGE DU DGV THEME
        private void remplirDgvTheme()
        {
            dgvThemes.Rows.Clear();
            foreach (Theme unTheme in Theme.listeThemes())
            {
                //dgvThemes.Rows.Add(unTheme.IdTheme, unTheme.NomTheme);
                dgvThemes.Rows.Add(unTheme.IdTheme, unTheme.NomTheme, unTheme.IdAtelier);
            }

        }

        //REMPLISSAGE COMBOBOX MODIFIER THEME
        private void remplirCbxModifierTheme()
        {
            cbxModifierTheme.Items.Clear();
            foreach (Theme unTheme in Theme.listeThemes())
            {
                cbxModifierTheme.Items.Add(unTheme.IdTheme);
            }
        }

        //REMPLISSAGE COMBOBOX SUPPRIMER THEME
        private void remplirCbxSupprimerTheme()
        {
            cbxSupprimerTheme.Items.Clear();
            foreach (Theme unTheme in Theme.listeThemes())
            {
                cbxSupprimerTheme.Items.Add(unTheme.IdTheme);
            }
        }


        private void btnCreerTheme_Click(object sender, EventArgs e)
        {
            if (txbCréerTheme1.Text.Length == 0 || txbCréerTheme2.Text.Length == 0 || txbCréerTheme3.Text.Length == 0)
            {
                MessageBox.Show("Erreur : Selectionne un Thème !");
                return;

            }
            else
            {
                Theme unNewTheme;
                unNewTheme = new Theme(int.Parse(txbCréerTheme1.Text), txbCréerTheme2.Text, int.Parse(txbCréerTheme3.Text));
                unNewTheme.ajouterTheme();

                //Vider les tbx.text
                txbCréerTheme1.Clear();
                txbCréerTheme2.Clear();
                txbCréerTheme3.Clear();
                

                //AFFICHER MSG VALIDER
                lblCreerThemeOK.Show();
            }

        }

        private void btnModifierTheme_Click(object sender, EventArgs e)
        {

            if (txbModifierTheme2.Text.Length == 0 || txbModifierTheme3.Text.Length == 0)
            {
                MessageBox.Show("Erreur : Selectionne un Thème !");
                return;
            }
            else
            {
                // on récupère l'index de la sélection dans la combobox
                int i = cbxModifierTheme.SelectedIndex;
                Theme unTheme;
                unTheme = Theme.listeThemes().ElementAt(i);
                unTheme.modifierTheme(cbxModifierTheme.SelectedIndex, txbModifierTheme2.Text, int.Parse(txbModifierTheme3.Text));


                //txbModifierAtelier2.Text = unAtelier.libelleAtelier;
                //txbModifierAtelier3.Text = unAtelier.nbParticipantsAtelier.ToString();


                //recuperer les tbx.text
                txbModifierTheme2.Clear();
                txbModifierTheme3.Clear();

                lblModifierThemeOK.Show();
            }
        }

        private void btnSupprimerTheme_Click(object sender, EventArgs e)
        {

            if (this.cbxSupprimerTheme.SelectedIndex == -1)
            {
                MessageBox.Show("Erreur : Selectionne un Thème !");
                return;
            }
            else
            {
                // on récupère l'index de la sélection dans la combobox
                int i = cbxSupprimerTheme.SelectedIndex;

                Theme unTheme;
                unTheme = Theme.listeThemes().ElementAt(i);
                unTheme.supprimerTheme();

                lblSupprimerThemeOK.Show();
            }
        }


        //BOUTON TOUT ANNULER THEME
        private void btnAnnulerTheme_Click(object sender, EventArgs e)
        {
            txbCréerTheme1.Clear();
            txbCréerTheme2.Clear();
            txbCréerTheme3.Clear();
            txbModifierTheme2.Clear();
            txbModifierTheme3.Clear();
        }

        #endregion

        

        


        #region Fonction innutiles

        private void dgvAteliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvThemes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvAteliers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbxModifierAteliers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txbCréerTheme1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void cbxSupprimerTheme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void dgvThemes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        
    }
}
